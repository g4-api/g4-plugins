using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace UiaDragDropLab
{
    /// <summary>
    /// The drag-and-drop lab window, which the live UIA drag-and-drop tests drive.
    /// </summary>
    /// <remarks>
    /// The window holds two cases. A source list (<c>SourceList</c>) starts a Windows drag of its items, and the
    /// target list (<c>TargetList</c>) accepts the drop and moves the item over, so a test finds
    /// <c>//List[@AutomationId='TargetList']//ListItem[@Name='Beta']</c> only after a real drop. A thumb
    /// (<c>DragThumb</c>) follows the captured mouse, and its status text reads <c>Thumb moved</c> once it moved more
    /// than <see cref="ThumbMovedPixels"/> pixels to the right. Every input the window receives is appended to
    /// <c>events.log</c> next to the executable, which shows what reached the window when a test fails. The window
    /// stays on top at a fixed position, so a drag at its screen points is not covered by another window.
    /// </remarks>
    public partial class MainWindow : Window
    {
        #region *** Constants    ***
        /// <summary>
        /// The horizontal distance, in pixels, after which the thumb status reads <c>Thumb moved</c>.
        /// </summary>
        public const double ThumbMovedPixels = 150;
        #endregion

        #region *** Fields       ***
        // The input log next to the executable; each line holds the local time and one received input.
        private static readonly string s_logPath = Path.Combine(AppContext.BaseDirectory, "events.log");

        // The source item under the last left press, or null when no drag can start from the current press.
        private ListBoxItem _pressedItem;

        // The window point of the last left press on the source list, from which the drag distance is measured.
        private Point _pressPoint;

        // The total horizontal distance the thumb moved since the window opened.
        private double _thumbDistance;
        #endregion

        #region *** Constructors ***
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class and logs the start.
        /// </summary>
        public MainWindow()
        {
            // Build the controls from the markup, then log the start so a test log shows each launch.
            InitializeComponent();
            WriteLog("started");
        }
        #endregion

        #region *** Methods      ***
        // Appends one time-stamped line to the input log next to the executable.
        private static void WriteLog(string text)
        {
            // Stamp the line with the local time to the millisecond, so it lines up with the driver log.
            var line = $"{DateTime.Now:HH:mm:ss.fff} {text}{Environment.NewLine}";
            File.AppendAllText(s_logPath, line);
        }

        // Remembers the pressed source item and the press point, so a following move can start the drag.
        private void OnSourceMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Resolve the list item under the press; a press between items starts no drag.
            _pressPoint = e.GetPosition(relativeTo: null);
            _pressedItem = ItemsControl.ContainerFromElement(SourceList, (DependencyObject)e.OriginalSource) as ListBoxItem;

            // Log the press with the item it found.
            WriteLog($"down at {_pressPoint} item={_pressedItem?.Content}");
        }

        // Starts a Windows drag of the pressed item once the pressed mouse moved past the system drag distance.
        private void OnSourceMouseMove(object sender, MouseEventArgs e)
        {
            // Log every move, because a drag that never starts shows up here first.
            var point = e.GetPosition(relativeTo: null);
            WriteLog($"move {point} left={e.LeftButton} pressed={_pressedItem != null}");

            // Start nothing without a pressed item or while the left button is up.
            if (_pressedItem == null || e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            // Wait until the pointer moved past the system drag distance in either direction, as Windows does.
            var delta = _pressPoint - point;
            var isHorizontalDrag = Math.Abs(delta.X) >= SystemParameters.MinimumHorizontalDragDistance;
            var isVerticalDrag = Math.Abs(delta.Y) >= SystemParameters.MinimumVerticalDragDistance;

            if (!isHorizontalDrag && !isVerticalDrag)
            {
                return;
            }

            // Clear the press first, so the moves during the drag start no second drag.
            var item = _pressedItem;
            _pressedItem = null;

            // Run the Windows drag of the item text; the call returns when the drop or the cancel ends it.
            WriteLog("DoDragDrop start");
            var result = DragDrop.DoDragDrop(item, $"{item.Content}", DragDropEffects.Move);
            WriteLog($"DoDragDrop end {result}");
        }

        // Accepts a text drag over the target list and refuses any other data.
        private void OnTargetDragOver(object sender, DragEventArgs e)
        {
            // Allow a move only for text, which is what the source list drags.
            WriteLog("dragover");
            e.Effects = e.Data.GetDataPresent(DataFormats.StringFormat)
                ? DragDropEffects.Move
                : DragDropEffects.None;
            e.Handled = true;
        }

        // Moves the dropped item from the source list into the target list.
        private void OnTargetDrop(object sender, DragEventArgs e)
        {
            // Read the dragged item text and log the drop.
            var name = (string)e.Data.GetData(DataFormats.StringFormat);
            WriteLog($"drop {name}");

            // Remove the item from the source list, so each item exists in one list only.
            foreach (ListBoxItem item in SourceList.Items)
            {
                if ($"{item.Content}" == name)
                {
                    SourceList.Items.Remove(item);
                    break;
                }
            }

            // Add the item to the target list, where the test looks for it.
            TargetList.Items.Add(new ListBoxItem { Content = name });
        }

        // Moves the thumb with the captured mouse and reports the distance it moved in the status text.
        private void OnThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            // Follow the mouse horizontally and add the change to the total distance.
            Canvas.SetLeft(DragThumb, Canvas.GetLeft(DragThumb) + e.HorizontalChange);
            _thumbDistance += e.HorizontalChange;

            // Name the result in the status text, which the test waits for.
            ThumbStatus.Text = _thumbDistance > ThumbMovedPixels
                ? "Thumb moved"
                : $"Thumb {Math.Round(_thumbDistance)}";
        }
        #endregion
    }
}
