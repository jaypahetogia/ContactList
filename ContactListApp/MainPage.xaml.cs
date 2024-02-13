using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace ContactListApp
{
    public partial class MainPage : ContentPage
    {
        private Dictionary<string, Contact> contacts = new Dictionary<string, Contact>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAddContact(object sender, EventArgs e)
        {
            var contact = new Contact
            {
                FirstName = FirstNameEntry.Text,
                LastName = LastNameEntry.Text,
                PhoneNumber = PhoneEntry.Text,
                Email = EmailEntry.Text
            };
            contacts[contact.FirstName + " " + contact.LastName] = contact;
            ClearEntries();
        }

        private void OnRemoveContact(object sender, EventArgs e)
        {
            string key = FirstNameEntry.Text + " " + LastNameEntry.Text;
            contacts.Remove(key);
            ClearEntries();
        }

        private void OnUpdateContact(object sender, EventArgs e)
        {
            string key = FirstNameEntry.Text + " " + LastNameEntry.Text;
            if (contacts.ContainsKey(key))
            {
                contacts[key] = new Contact
                {
                    FirstName = FirstNameEntry.Text,
                    LastName = LastNameEntry.Text,
                    PhoneNumber = PhoneEntry.Text,
                    Email = EmailEntry.Text
                };
            }
            ClearEntries();
        }

        private void OnSearchContact(object sender, EventArgs e)
        {
            string key = FirstNameEntry.Text + " " + LastNameEntry.Text;
            if (contacts.TryGetValue(key, out Contact contact))
            {
                FirstNameEntry.Text = contact.FirstName;
                LastNameEntry.Text = contact.LastName;
                PhoneEntry.Text = contact.PhoneNumber;
                EmailEntry.Text = contact.Email;
            }
        }

        private void ClearEntries()
        {
            FirstNameEntry.Text = string.Empty;
            LastNameEntry.Text = string.Empty;
            PhoneEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
        }
    }
}