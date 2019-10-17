using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//alt+shift+enter --> fullscreen
namespace Project7
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Name = "Bozydar", LastName = "Bystry", BirthDate = new DateTime(1956, 7, 12) };
            Person p2 = new Person { Name = "Janusz", LastName = "Klin", BirthDate = new DateTime(1981, 4, 1) };
            Group g1 = new Group { NameOfGroup = "C3", TypeOfOrganisation = "automobile" };
            Group g2 = new Group { NameOfGroup = "X5", TypeOfOrganisation = "cars" };
            g1.AddMember(p1);
            g1.AddMember(p1);
            g1.AddMember(p2);
            g2.AddMember(p2);
            g1.SetBoss(p2);
            Console.WriteLine(p2);
            Console.WriteLine("-----------------------");
            Console.WriteLine(g1);
            Console.ReadKey();
        }
    }
}

public class Group
{
    public String NameOfGroup { get; set; }
    public String TypeOfOrganisation { get; set; }
    public List<Person> Members { get; } = new List<Person>();
    public Person Boss { get; private set; }

    public void AddMember(Person person)
    {
        if (!Members.Contains(person))
        {
            Members.Add(person);
            person.AddGroup(this);
        }
    }

    public void RemovePerson(Person person)
    {
        if (Members.Contains(person))
        {
            Members.Remove(person);
            person.RemoveGroup(this);
        }
    }

    public void SetBoss(Person person)
    {
        if (Boss == null && IsMember(person))
        {
            Boss = person;
            person.SetBossedGroup(this);
        }
    }

    public bool IsMember(Person person)
    {
        return Members.Contains(person);
    }

    public override string ToString()
    {
        String s = NameOfGroup + " " + TypeOfOrganisation + "\nList of Members:";
        if (!Members.Any())
        {
            s += "NO MEMBERS";
        }
        foreach (Person person in Members)
        {
            s += "\n" + person.ToStringSimple();
        }
        return s;
    }

    public string ToStringSimple()
    {
        String s = NameOfGroup + " " + TypeOfOrganisation;
        return s;
    }
}

public class Person
{
    public string Name { get; set; }
    public String LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Group> Groups { get; } = new List<Group>();
    public Group BossedGroup { get; private set; }

    public override string ToString()
    {
        String s = Name + " " + LastName + " " + BirthDate + "\nPerson is member of:";
        if (!Groups.Any())
        {
            s += " 0 groups";
        }
        foreach (Group group in Groups)
        {
            s += "\n" + group.ToStringSimple();

        }
        s += BossedGroup == null ? "\nPerson isn't a boss" : "\nPerson is a boss of: " + BossedGroup.ToStringSimple();
        return s;
    }

    public String ToStringSimple()
    {
        String s = Name + " " + LastName + " " + BirthDate;
        return s;
    }

    public void RemoveGroup(Group group)
    {
        if (Groups.Contains(group))
        {
            Groups.Remove(group);
            group.RemovePerson(this);
        }
    }

    public void AddGroup(Group group)
    {
        if (!Groups.Contains(group))
        {
            Groups.Add(group);
            group.AddMember(this);
        }
    }

    internal void SetBossedGroup(Group group)
    {
        if (BossedGroup == null)
        {
            BossedGroup = group;
            group.SetBoss(this);
        }
    }
}