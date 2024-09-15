using System.Windows;

namespace rpg_character_creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> traits = new List<string>();
        List<string> skills = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            Traits.Items.Add("Strength");
            Traits.Items.Add("Intelligence");
            Traits.Items.Add("Speed");
            Traits.Items.Add("Durability");

            Skills.Items.Add("Sword throw");
            Skills.Items.Add("Magic spell");
            Skills.Items.Add("Turbo");
            Skills.Items.Add("Magic armor");

            Races.Items.Add("Human");
            Races.Items.Add("Reptilian");
            Races.Items.Add("Elf");
            Races.Items.Add("Furry");
        }

        private void AddTraitButtonClicked(object sender, RoutedEventArgs e)
        {
            string trait = (string)Traits.SelectedItem;
            TraitListView.Items.Add(trait);
        }        
        private void RemoveTraitButtonClicked(object sender, RoutedEventArgs e)
        {
            TraitListView.Items.Remove(Traits.SelectedItem);
        }
        private void AddSkillButtonClicked(object sender, RoutedEventArgs e)
        {
            string skill = (string)Skills.SelectedItem;
            SkillListView.Items.Add(skill);
        }
        private void RemoveSkillButtonClicked(object sender, RoutedEventArgs e)
        {
            SkillListView.Items.Remove(Skills.SelectedItem);
        }
    }
}