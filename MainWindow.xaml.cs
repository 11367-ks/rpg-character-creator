using System.Windows;
using System.Windows.Media.Imaging;

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
            if (!TraitListView.Items.Contains(trait))
            {
                TraitListView.Items.Add(trait);
            }
        }
        private void RemoveTraitButtonClicked(object sender, RoutedEventArgs e)
        {
            var selectedItems = TraitListView.SelectedItems.Cast<object>().ToList();

            foreach (var item in selectedItems) {
                TraitListView.Items.Remove(item);
            }
        }
        private void PurgeTraitButtonClicked(object sender, RoutedEventArgs e)
        {
            TraitListView.Items.Clear();
        }

        private void AddSkillButtonClicked(object sender, RoutedEventArgs e)
        {
            string skill = (string)Skills.SelectedItem;
            if (!SkillListView.Items.Contains(skill))
            {
                SkillListView.Items.Add(skill);
            }
        }
        private void RemoveSkillButtonClicked(object sender, RoutedEventArgs e)
        {
            var selectedItems = SkillListView.SelectedItems.Cast<object>().ToList();

            foreach (var item in selectedItems)
            {
                SkillListView.Items.Remove(item);
            }
        }
        private void PurgeSkillButtonClicked(object sender, RoutedEventArgs e)
        {
            SkillListView.Items.Clear();
        }

        private void Races_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (Races.SelectedItem)
            {
                case "Human":
                    RaceThumbnail.Source = new BitmapImage(new Uri(@"images\human.png", UriKind.Relative));
                    break;
                case "Reptilian":
                    RaceThumbnail.Source = new BitmapImage(new Uri(@"images\reptilian.png", UriKind.Relative));
                    break;
                case "Elf":
                    RaceThumbnail.Source = new BitmapImage(new Uri(@"images\elf.png", UriKind.Relative));
                    break;
                case "Furry":
                    RaceThumbnail.Source = new BitmapImage(new Uri(@"images\furry.png", UriKind.Relative));
                    break;
                default:
                    RaceThumbnail.Source = new BitmapImage(new Uri(@"images\empty.png", UriKind.Relative));
                    break;
            }
        }

        private void RandomizeButtonClick(object sender, RoutedEventArgs e)
        {
            // Randomize traits
            TraitListView.Items.Clear();
            int amount_of_traits = new Random().Next(4) + 1;
            int rolled_trait;
            List<int> rolled_traits = new List<int>();
            for (int i = 0; i < amount_of_traits; i++)
            {
                do
                {
                    rolled_trait = new Random().Next(4);
                } while (rolled_traits.Contains(rolled_trait));
                rolled_traits.Add(rolled_trait);
                switch (rolled_trait) {
                    case 0:
                        TraitListView.Items.Add("Strength");
                        break;
                    case 1:
                        TraitListView.Items.Add("Intelligence");
                        break;
                    case 2:
                        TraitListView.Items.Add("Speed");
                        break;
                    case 3:
                        TraitListView.Items.Add("Durability");
                        break;
                    default:
                        break;
                }
            }

            // Randomize Skills
            SkillListView.Items.Clear();
            int amount_of_skills = new Random().Next(4) + 1;
            int rolled_skill;
            List<int> rolled_skills = new List<int>();
            for(int i = 0; i < amount_of_skills; i++)
            {
                do
                {
                    rolled_skill = new Random().Next(4);
                } while (rolled_skills.Contains(rolled_skill));
                rolled_skills.Add(rolled_skill);
                switch (rolled_skill)
                {
                    case 0:
                        SkillListView.Items.Add("Sword throw");
                        break;
                    case 1:
                        SkillListView.Items.Add("Magic spell");
                        break;
                    case 2:
                        SkillListView.Items.Add("Turbo");
                        break;
                    case 3:
                        SkillListView.Items.Add("Magic armor");
                        break;
                    default:
                        break;
                }
            }

            // Randomize Race
            int randomized_race = new Random().Next(4);
            switch (randomized_race)
            {
                case 0:
                    Races.SelectedItem = "Human";
                    break;
                case 1:
                    Races.SelectedItem = "Reptilian";
                    break;
                case 2:
                    Races.SelectedItem = "Elf";
                    break;
                case 3:
                    Races.SelectedItem = "Furry";
                    break;
                default:
                    break;
            }

            // Randomize character history
            int rolled_history = new Random().Next(2);
            switch (rolled_history) {
                case 0:
                    History.Text = "Born on the outskirts of the Whispering Woods, a dense forest rumored to be filled with ancient magic and dangerous creatures. The son of a human hunter and an elven herbalist, grew up learning to navigate both the wild and the civilized world, never truly belonging to either. His father, a skilled marksman, taught him how to hunt and survive in the wild, while his mother passed down knowledge of the forest’s secrets and the elven traditions of herbalism.";
                    break;
                case 1:
                    History.Text = "Grew up in the bustling city of Rivermoor, always one step ahead of trouble. Orphaned at a young age, she learned to survive on the streets through quick hands and quicker wits. By the age of 15, become one of the best thieves in the city, known for her charm and her knack for slipping away unseen.";
                    break;
            }
        }
    }
}