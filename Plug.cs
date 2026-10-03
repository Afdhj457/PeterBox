// C# WinForms 中运行 HTML 的核心代码
using System.Windows.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        WebBrowser browser = new WebBrowser();
        browser.Dock = DockStyle.Fill;
        browser.DocumentText = @"<html><body><h1>Hello from C#!</h1></body></html>";
        this.Controls.Add(browser);
    }
}