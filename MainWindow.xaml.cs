using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;




namespace Laboration_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users = new();
        private ViewModel viewModel = new();

        private User _userSelected = new User();

        public MainWindow()
        {
            InitializeComponent();
            
            userListBox.ItemsSource = users;
        }

        public async void ButtonClickLoadList(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            

            if (openFileDialog.ShowDialog() == true)
            {
                users.Clear();
                var people = await viewModel.UpdateList(openFileDialog.FileName);

                foreach (var user in people)
                {   
                    users.Add(user);
                }

                foreach (User user in users)
                {
                    Debug.WriteLine($"{user.firstName} - {user.surname} - {user.email}");
                }

                MessageBox.Show("List loaded succesfully.");
            }
            else
            {
                MessageBox.Show("Please choose a file.");
            }
        }

        public async void ButtonClickAddUser(object sender, RoutedEventArgs e)
        {
            if(await viewModel.AddUsers(firstName.Text, surname.Text, email.Text) == 1){
                users.Add(new User() { firstName = firstName.Text, surname = surname.Text, email = email.Text });
                MessageBox.Show($"Användare skapad. \n Namn: {firstName.Text} \n Efternman: {surname.Text} \n Epost: {email.Text}");
            }
            else
            {
                MessageBox.Show("Användare blev inte skapad. Fyll in alla fält.");
            }
        }

        public void userListBoxLeftButtonUp(object sender, RoutedEventArgs e)
        {
            if(userListBox.Items.Count > 0)
            {
                _userSelected = (User)userListBox.Items.GetItemAt(userListBox.SelectedIndex);
                userShowcaseFirstName.Text = _userSelected.firstName;
                userShowcaseSurname.Text = _userSelected.surname;
                userShowcaseEmail.Text = _userSelected.email;
            }
        }
    }
}
