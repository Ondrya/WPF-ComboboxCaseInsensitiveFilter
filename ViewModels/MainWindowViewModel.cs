using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ComboboxCaseInsensitiveFilter.Models;

namespace ComboboxCaseInsensitiveFilter.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<Person> persons;
        private Person selectedPerson;
        private string personFilter;
        private List<Person> personsSource;

        public List<Person> PersonsSource
        {
            get => personsSource;
            set 
            { 
                personsSource = value;
                OnPropertyChanged();
            }
        }

        public string PersonFilter
        {
            get => personFilter;
            set 
            {
                personFilter = value;
                Persons = filterPersonList(value);
                Debug.WriteLine($"Введён фильтр для поиска: {PersonFilter}. Отфильтровано: {Persons.Count} элементов");
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> Persons
        {
            get => persons;
            set 
            { 
                persons = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedPerson
        {
            get => selectedPerson;
            set 
            {
                if (selectedPerson == value) return;
                selectedPerson = value;
                OnPropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            PersonsSource = new List<Person>()
            {
                new Person("Андрей", 20),
                new Person("Алексей", 22),
                new Person("Сергей", 23),
                new Person("Матвей", 24),
                new Person("Иван", 25),
                new Person("Ирина", 26),
                new Person("Илья", 27)
            };

            Persons = filterPersonList();
        }

        private ObservableCollection<Person> filterPersonList(string filter = "")
        {
            var result = new ObservableCollection<Person>();
            foreach (var item in PersonsSource)
            {
                if (String.IsNullOrWhiteSpace(filter)) {
                    result.Add(item); 
                }
                else
                {
                    if (item.Name.CaseInsensitiveContains(filter)) result.Add(item);
                }
                
            }

            return result;
        }
    }

    public static class Extensions
    {
        public static bool CaseInsensitiveContains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }
    }
}
