using System.Windows;

namespace rpg_character_creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Treats.Items.Add("Strength");
            Treats.Items.Add("Intelligence");
            Treats.Items.Add("Speed");
            Treats.Items.Add("Durability");

            Skills.Items.Add("Sword throw");
            Skills.Items.Add("Magic spell");
            Skills.Items.Add("Turbo");
            Skills.Items.Add("Magic armor");

            Races.Items.Add("Human");
            Races.Items.Add("Reptilian");
            Races.Items.Add("Elf");
            Races.Items.Add("Furry");
        }
    }
}