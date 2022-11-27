using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
namespace appDevnest
{
    /// <summary>
    /// PersonInfo class to store the information from the input easier
    /// </summary>
    public class PersonInfo
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }

        /// <summary>
        /// Static method to call it more easier (Don't need instance to call Solver())
        /// </summary>
        /// <param name="input_example"></param>
        /// <returns></returns>
        public static string Solver(string input_example)
        {
            List<PersonInfo> personInfoList = new List<PersonInfo>();

            string output_example = "";

            //I split the input_string for new lines
            var peopleInformationStringList = input_example.Split("\n");
            //Removing the header
            peopleInformationStringList = peopleInformationStringList.Skip(1).ToArray();

            // peopleInformationStringList is of type = ["FullName1, Email1, Location1", "FullName2, Email2, Location2", ...]
            // I will iterate over the array and I will build our list of PersonInfo objects
            foreach (string peopleInfoString in peopleInformationStringList)
            {
                var infoPerPerson = peopleInfoString.Split(",");
                PersonInfo person = new PersonInfo()
                {
                    FullName = infoPerPerson[0],
                    Email = infoPerPerson[1],
                    Location = infoPerPerson[2]
                };
                personInfoList.Add(person);

            }

            //Using the Distinct() I remove the duplicates from the list of Personinfo objects and group them by the first letter og the FullName field using GroupBy()
            var groupedPersons = personInfoList.Distinct(new PersonInfoComparer()).GroupBy(x => x.FullName.Substring(0, 1).ToUpper()).ToList();

            //we iterate over each group and construct the output string at each step
            foreach (var group in groupedPersons)
            {
                output_example += group.Key + ":\n";
                foreach (var person in group.ToList())
                {

                    output_example += person.FullName + "," + person.Email + "," + person.Location + "\n";
                }
                output_example += "\n";


            }

            //returns the output string, without the extra end line at the end
            return output_example.Substring(0, output_example.Length - 1);
        }

    }

    /// <summary>
    /// Helper class for method Distinct() to remove the duplicates from a list of PersonInfo objects
    /// Equals method used for comparing 2 PersonInfo objects
    /// </summary>
    public class PersonInfoComparer : IEqualityComparer<PersonInfo>
    {
        public bool Equals(PersonInfo x, PersonInfo y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            return x.Email == y.Email && x.FullName == y.FullName && x.Location == y.Location;
        }

        public int GetHashCode(PersonInfo personInfo)
        {
            if (Object.ReferenceEquals(personInfo, null)) return 0;

            //Get hash code for the FullName field if it is not null.
            int hashPersonInfoFullName = personInfo.FullName == null ? 0 : personInfo.FullName.GetHashCode();

            //Get hash code for the Email field if it is not null.
            int hashPersonInfoEmail = personInfo.Email == null ? 0 : personInfo.Email.GetHashCode();

            //Get hash code for the Lcoation field if it is not null.
            int hashPersonInfoLocation = personInfo.Location == null ? 0 : personInfo.Location.GetHashCode();

            //Calculate the hash code for the PersonInfo object.
            return hashPersonInfoFullName ^ hashPersonInfoEmail ^ hashPersonInfoLocation;
        }
    }


    public class Program
    {

        static void Main(string[] args)
        {
            List<PersonInfo> personInfoList = new List<PersonInfo>();
            string input_example = "full_name, email, location\nAnita, anita@email.com, California\nAron, aron.bla@email.com, California\nAron, aron.bla@email.com, California\nCosmin, kox@bla.com, Giurgiu\nCrina, ggl@test.com, Letcani\nBogdan, vox@example.com, Resita";
            string output_example = PersonInfo.Solver(input_example);


            Console.WriteLine(output_example);
        }

    }
}
