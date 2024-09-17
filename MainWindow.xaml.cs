using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace rpg_character_creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        // Three enumeration fields for traits, skills and races
        enum TraitsEnum
        {
            Strength,
            Intelligence,
            Speed,
            Durabilty,
            Weapon_Master,
            Survivalist,
            Melodic_Healer,
            Holy_Aura
        }

        enum SkillsEnum
        {
            Sword_Throw,
            Magic_Spell,
            Turbo,
            Magic_Armor,
            War_Cry,
            Berserkers_Fury,
            Elemental_Surge,
            Arcane_Blast
        }

        enum RacesEnum
        {
            Human,
            Reptilian,
            Elf,
            Furry
        }

        enum StoryEnum
        {
            Good,
            Neutral,
            Evil
        }
        public MainWindow()
        {
            // App initialization and adding enum fields to corresponding comboboxes
            InitializeComponent();

            foreach (var trait in (TraitsEnum[]) Enum.GetValues(typeof(TraitsEnum))) {
                Traits.Items.Add(trait.ToString());
            }

            foreach (var skill in (SkillsEnum[]) Enum.GetValues(typeof(SkillsEnum))) {
                Skills.Items.Add(skill.ToString());
            }

            foreach (var race in (RacesEnum[]) Enum.GetValues(typeof(RacesEnum))) {
                Races.Items.Add(race.ToString());
            }
        }

        // Trait add button click event handler function
        private void AddTraitButtonClicked(object sender, RoutedEventArgs e)
        {
            string trait = (string)Traits.SelectedItem;
            if (!TraitListView.Items.Contains(trait))
            {
                TraitListView.Items.Add(trait);
            }
        }

        // Trait remover button click event handler function
        private void RemoveTraitButtonClicked(object sender, RoutedEventArgs e)
        {
            var selectedItems = TraitListView.SelectedItems.Cast<object>().ToList();

            foreach (var item in selectedItems) {
                TraitListView.Items.Remove(item);
            }
        }

        // Traits listView purge click event handler function
        private void PurgeTraitButtonClicked(object sender, RoutedEventArgs e)
        {
            TraitListView.Items.Clear();
        }

        // Skill add button click event handler function
        private void AddSkillButtonClicked(object sender, RoutedEventArgs e)
        {
            string skill = (string)Skills.SelectedItem;
            if (!SkillListView.Items.Contains(skill))
            {
                SkillListView.Items.Add(skill);
            }
        }

        // Skill remover button click event handler function
        private void RemoveSkillButtonClicked(object sender, RoutedEventArgs e)
        {
            var selectedItems = SkillListView.SelectedItems.Cast<object>().ToList();

            foreach (var item in selectedItems)
            {
                SkillListView.Items.Remove(item);
            }
        }

        // Skills listView purge click event handler function
        private void PurgeSkillButtonClicked(object sender, RoutedEventArgs e)
        {
            SkillListView.Items.Clear();
        }

        // Race selection change event handler function
        private void Races_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            RaceThumbnail.Source = new BitmapImage(new Uri(@$"images\{Races.SelectedItem}.png", UriKind.Relative));
        }

        // Character randomizer button click event handler function
        private void RandomizeButtonClicked(object sender, RoutedEventArgs e)
        {
            // Randomize traits
            int amount_of_traits_in_enum = Enum.GetNames(typeof(TraitsEnum)).Length;

            TraitListView.Items.Clear();
            int amount_of_traits = new Random().Next(amount_of_traits_in_enum) + 1;
            int rolled_trait;
            List<int> rolled_traits = new List<int>();
            for (int i = 0; i < amount_of_traits; i++)
            {
                do
                {
                    rolled_trait = new Random().Next(amount_of_traits_in_enum);
                } while (rolled_traits.Contains(rolled_trait));
                rolled_traits.Add(rolled_trait);
                TraitListView.Items.Add(Enum.GetName(typeof(TraitsEnum), rolled_trait));
            }

            // Randomize Skills
            int amount_of_skills_in_enum = Enum.GetNames(typeof(SkillsEnum)).Length;

            SkillListView.Items.Clear();
            int amount_of_skills = new Random().Next(amount_of_skills_in_enum) + 1;
            int rolled_skill;
            List<int> rolled_skills = new List<int>();
            for(int i = 0; i < amount_of_skills; i++)
            {
                do
                {
                    rolled_skill = new Random().Next(amount_of_skills_in_enum);
                } while (rolled_skills.Contains(rolled_skill));
                rolled_skills.Add(rolled_skill);
                SkillListView.Items.Add(Enum.GetName(typeof(SkillsEnum), rolled_skill));
            }

            // Randomize Race
            int amount_of_races_in_enum = Enum.GetNames(typeof(RacesEnum)).Length;
            int randomized_race = new Random().Next(amount_of_races_in_enum);
            Races.SelectedItem = Enum.GetName(typeof(RacesEnum), randomized_race);

            // Randomize character history
            int rolled_history = new Random().Next(Enum.GetNames(typeof(StoryEnum)).Length);
            switch (rolled_history) {
                case (int)StoryEnum.Good:
                    History.Text = "Born in a humble village, the character discovered a hidden talent for healing at a young age, often tending to the sick and injured. After a devastating attack on their home, they vowed to protect the innocent and seek justice for those who cannot defend themselves. With an unyielding spirit and a heart full of compassion, they now journey across the land, gathering allies and spreading hope wherever they go. Their ultimate goal is to create a world where peace prevails and kindness reigns supreme.";
                    break;
                case (int)StoryEnum.Neutral:
                    History.Text = "Hailing from a lineage of scholars, the character has always been fascinated by the balance of nature and civilization. They wander the world as a historian and diplomat, seeking to understand different cultures while maintaining neutrality in conflicts. With a knack for negotiation and a deep respect for knowledge, they often find themselves mediating disputes and documenting the tales of both heroes and villains. Their ultimate goal is to preserve the wisdom of the past while fostering understanding among diverse peoples, believing that true progress lies in harmony rather than division.";
                    break;
                case (int)StoryEnum.Evil:
                    History.Text = "Raised in a family of notorious thieves and con artists, the character learned the art of deception at a young age. They quickly climbed the ranks of the criminal underworld, becoming known for their ruthless tactics and disregard for the well-being of others. Driven by greed and a thirst for power, they have amassed a small fortune through illegal means. However, their actions have earned them the enmity of many, including powerful figures in the government and the criminal elite. Now, with a bounty on their head and enemies closing in, they must decide whether to continue their life of crime or seek redemption.";
                    break;
                default:
                    History.Text = "";
                    break;
            }
        }

        // Character creation button click event handler function
        private void CreateCharacterClicked(object sender, RoutedEventArgs e)
        {
            // Saving creation to Character.txt in Documents folder
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outFile = new StreamWriter(Path.Combine(docPath, "Character.txt")))
            {
                List<string> traits = TraitListView.Items.Cast<string>().ToList();
                List<string> skills = SkillListView.Items.Cast<string>().ToList();

                outFile.WriteLine("Race: " + Races.Text);

                outFile.WriteLine("Traits:");
                foreach (string trait in traits) {
                    outFile.WriteLine("\t- " + trait);
                }
                outFile.WriteLine("Skills:");
                foreach (string skill in skills) {
                    outFile.WriteLine("\t- " + skill);
                }
                outFile.WriteLine("Character story:\n" + History.Text);
            }
        }
    }
}