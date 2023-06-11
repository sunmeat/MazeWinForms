namespace Maze
{
    public partial class LevelForm : Form
    {
        public Maze maze; // ������ �� ������ ����� ������������� � ���������
        public Character Hero;

        public LevelForm()
        {
            InitializeComponent();
            FormSettings();
            StartGameProcess();
        }

        public void FormSettings()
        {
            Text = Configuration.Title;
            BackColor = Configuration.Background;

            // ������� ���������� ������� �����
            ClientSize = new Size(
                Configuration.Columns * Configuration.PictureSide,
                Configuration.Rows * Configuration.PictureSide);

            StartPosition = FormStartPosition.CenterScreen;
        }

        public void StartGameProcess()
        {
            Hero = new Character(this);
            maze = new Maze(this);
            maze.Generate();
            maze.Show();
        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                // �������� �� ��, �������� �� ������ ������
                if (maze.cells[Hero.PosY, Hero.PosX + 1].Type != CellType.WALL)
                {
                    Hero.Clear();
                    Hero.MoveRight();
                    Hero.Show();
                }
            }
            else if (e.KeyCode == Keys.Left && Hero.PosX != 0)
            {
                // �������� �� ��, �������� �� ������ �����
                if (maze.cells[Hero.PosY, Hero.PosX - 1].Type != CellType.WALL)
                {
                    Hero.Clear();
                    Hero.MoveLeft();
                    Hero.Show();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                // �������� �� ��, �������� �� ������ ����
                if (maze.cells[Hero.PosY - 1, Hero.PosX].Type != CellType.WALL)
                {
                    Hero.Clear();
                    Hero.MoveUp();
                    Hero.Show();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                // �������� �� ��, �������� �� ������ ����
                if (maze.cells[Hero.PosY + 1, Hero.PosX].Type != CellType.WALL)
                {
                    Hero.Clear();
                    Hero.MoveDown();
                    Hero.Show();
                }
            }
        }
    }
}