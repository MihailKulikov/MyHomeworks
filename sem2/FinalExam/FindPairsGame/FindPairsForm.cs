using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace FindPairsGame
{
    /// <summary>
    /// Represents GUI for Find Pairs Game.
    /// </summary>
    public partial class FindPairsForm : Form
    {
        private const string WinMessage = "You won!";
        private const int ShowDelayInMilliseconds = 500;
        
        private readonly TableLayoutPanel tableLayoutPanel;
        private readonly Button[,] buttons;
        private readonly FindPairsCore core;
        private readonly Queue<(int x, int y)> clickedButtonsCoordinate = new Queue<(int x, int y)>();
        private readonly Queue<System.Timers.Timer> timers = new Queue<System.Timers.Timer>();
        
        /// <summary>
        /// Initialize new instance of Find Pairs Game with specified size.
        /// </summary>
        /// <param name="size">Specified size.</param>
        public FindPairsForm(int size)
        {
            core = new FindPairsCore(size);
            InitializeComponent();

            tableLayoutPanel = new TableLayoutPanel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                                          | AnchorStyles.Left
                                          | AnchorStyles.Right,
                ColumnCount = size
            };
            for (var i = 0; i < size; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / size));
            }
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel1";
            tableLayoutPanel.RowCount = size;
            for (var i = 0; i < size; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / size));
            }
            tableLayoutPanel.Size = new Size(370, 340);
            tableLayoutPanel.TabStop = false;

            buttons = new Button[size, size];
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                        BackColor = SystemColors.ButtonHighlight,
                        Font = new Font("Microsoft JhengHei", 12F, FontStyle.Regular,
                            GraphicsUnit.Point, 0),
                        Name = $"button{i}{j}",
                        UseVisualStyleBackColor = false,
                        TabStop = false
                    };
                    buttons[i, j].Click += Button_Click;
                    tableLayoutPanel.Controls.Add(buttons[i, j], j, i);
                }
            }
            Controls.Add(tableLayoutPanel);
            tableLayoutPanel.ResumeLayout(false);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            for (var x = 0; x < buttons.GetLength(0); x++)
            {
                for (var y = 0; y < buttons.GetLength(1); y++)
                {
                    if (buttons[x, y] != (Button) sender) continue;
                    buttons[x, y].Text = core.CellsValue[x, y].ToString();
                    buttons[x, y].Enabled = false;
                    
                    clickedButtonsCoordinate.Enqueue((x, y));
                    var newTimer = new System.Timers.Timer {Interval = ShowDelayInMilliseconds, AutoReset = false, Enabled = true};
                    newTimer.Elapsed += OnTimedEvent;
                    timers.Enqueue(newTimer);
                }
            }
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            var firstClickedButtonCoordinates = clickedButtonsCoordinate.Dequeue();
            foreach (var (xCor, yCor) in core.ChangeCellsVisibleOnClick(firstClickedButtonCoordinates))
            {
                buttons[xCor, yCor].Enabled = true;
                buttons[xCor, yCor].Text = "";
            }

            var firstTimer = timers.Dequeue();
            firstTimer.Dispose();
            
            if (core.IsGameOver())
            {
                MessageBox.Show(WinMessage);
            }
        }
    }
}
