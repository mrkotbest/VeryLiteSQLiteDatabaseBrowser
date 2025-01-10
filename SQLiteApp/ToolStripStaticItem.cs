using System.Drawing;
using System.Windows.Forms;

namespace SQLiteApp
{
    public class ToolStripStaticItem : ToolStripMenuItem
    {
        public ToolStripStaticItem(string text) : base(text) { Enabled = false; }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            TextRenderer.DrawText(
                e.Graphics,
                Text,
                Font,
                new Rectangle(Point.Empty, Size),
                Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left
            );
        }
    }
}
