using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrialTest2.DAL
{
    public enum Sex
    {
        Male,
        Female,
    }

    [AttributeUsage(AttributeTargets.Property)]                                     // Attribute [5]
    class Validation: Attribute
    {
        public uint MaxLength { get; set; }
    }

    class Human
    {
        public Guid Id { get; private set; }                                        // Encapsulatetion [1]
        [Validation(MaxLength = 10)]
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Gender { get; set; }
        public Human(string name, int age, Sex gemder)
        {
            this.OnValidate += new Validate(OnCreateValidator);
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Gender = gemder;
            this.InvokeOnValidate();
            
        }

        public int Error { get; set; }
        private delegate void Validate();
        private event Validate OnValidate;                                          // Event [6]
        private void InvokeOnValidate()
        {
            Validate handler = OnValidate;
            if (handler != null)
            {
                handler();
            }
        }
        private void OnCreateValidator()
        {
            uint maxLength = uint.MinValue;
            Type type = this.GetType();
            var member = type.GetProperty("Name");
            var name =  member.GetValue(this,null);
            var attributes = member.GetCustomAttributes(typeof (Validation), false);
            foreach (var attribute in attributes)
            {
                if (attribute is Validation)
                {
                    maxLength = (attribute as Validation).MaxLength;
                    if (((string)name).Length > maxLength)
                    {
                        Error += 1;
                        Console.WriteLine("Name value length is too long. Value should be less than " + maxLength);
                    }
                }
            }
            
        }

        public virtual void Walk()
        {
            Console.WriteLine(typeof(Human) + " walk`s");
        }
    }

    public interface IAdult
    {
        void Work();                    
        
    }

    class Mother : Human, IAdult                                                    // Inheritance [2]
    {
        public Daughter Daughter { get; set; }
        public Mother(string name, int age, Sex gemder) :base (name, age, gemder){}

        public override void Walk()                                                 // Polymorphism [3]
        {
            Console.WriteLine("Mother: {0}, walks", Name);
        }

        public void Work()
        {
            Console.WriteLine("Father: {0}, works", Name);
        }
    }

    class Father : Human, IAdult                                                    // Interface [4]
    {
        public Daughter Daughter { get; set; }
        public Father(string name, int age, Sex gemder) :base (name, age, gemder){}

        public override void Walk()                                                 
        {
            Console.WriteLine("Father: {0}, walks", Name);
        }

        public void Work()
        {
            Console.WriteLine("Father: {0}, works", Name);
        }
    }

    class Daughter : Human
    {
        public Guid FatherId { get; set; }
        public Guid MotherId { get; set; }
        public Daughter(string name, int age, Sex gemder) : base(name, age, gemder) { }

        public override void Walk()                                                 
        {
            Console.WriteLine("Daughter: {0}, walks", Name);
        }
    }

    class DataStore
    {
        public List<Mother> Mothers { get; set; }                                   // Generics [7]
        public List<Father> Fathers { get; set; }
        public List<Daughter> Daughters { get; set; }

        public DataStore()
        {
            Mothers = new List<Mother>(new[]
                                           {
                                               new Mother("Lulu", 30, Sex.Female) { }, 
                                               new Mother("Lala", 30, Sex.Female) { },
                                               new Mother("Lolo", 30, Sex.Female) { },
                                           });

            Fathers = new List<Father>(new[]
                                           {
                                               new Father("Glen", 30, Sex.Male) { }, 
                                               new Father("Bill", 30, Sex.Male) { },
                                               new Father("Stefan", 30, Sex.Male) { }
                                           });

            Daughters = new List<Daughter>(new[]
                                           {
                                               new Daughter("Sam", 10, Sex.Female)  { MotherId = Mothers[0].Id, FatherId = Fathers[0].Id}, 
                                               new Daughter("Sara", 10, Sex.Female) { MotherId = Mothers[1].Id, FatherId = Fathers[1].Id },
                                               new Daughter("Liza", 10, Sex.Female) { MotherId = Mothers[2].Id, FatherId = Fathers[2].Id }
                                           });

            Mothers[0].Daughter = Daughters.FirstOrDefault(d => d.MotherId == Mothers[0].Id);
            Fathers[0].Daughter = Daughters.FirstOrDefault(d => d.FatherId == Fathers[0].Id);

            Mothers[1].Daughter = Daughters.FirstOrDefault(d => d.MotherId == Mothers[1].Id);
            Fathers[1].Daughter = Daughters.FirstOrDefault(d => d.FatherId == Fathers[1].Id);

            Mothers[2].Daughter = Daughters.FirstOrDefault(d => d.MotherId == Mothers[2].Id);
            Fathers[2].Daughter = Daughters.FirstOrDefault(d => d.FatherId == Fathers[2].Id);
        }
     }

    class DataAccess
    {
        private DataStore _dataStore;
        public DataAccess(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public IEnumerable GetAllFathers()
        {
            return _dataStore.Fathers.Select(f => f);
        }

        public Father GetFather(Guid id)
        {
            return _dataStore.Fathers.FirstOrDefault(f => f.Id == id);
        }

        public void AddFather(Father father)
        {
            _dataStore.Fathers.Add(father);
        }

        public void UpdateFather(Father father)
        {
            var oldFather = _dataStore.Fathers.FirstOrDefault(f => f.Id == father.Id);
            // Update each property
        }

        public void RemoveFather(Guid id)
        {
            _dataStore.Fathers.Remove(_dataStore.Fathers.FirstOrDefault(f => f.Id == id));
        }

        public IEnumerable GetAllMothers()
        {
            return _dataStore.Mothers.Select(m => m);
        }

        public Mother GetMother(Guid id)
        {
            return _dataStore.Mothers.FirstOrDefault(m => m.Id == id);
        }

        public void AddMother(Mother mother)
        {
            if (mother.Error == 0)
            {
                _dataStore.Mothers.Add(mother);
            }
            
        }

        public void UpdateMother(Mother mother)
        {
            var oldFather = _dataStore.Mothers.FirstOrDefault(m => m.Id == mother.Id);
            // Update each property
        }

        public void RemoveMother(Guid id)
        {
            _dataStore.Mothers.Remove(_dataStore.Mothers.FirstOrDefault(m => m.Id == id));
        }

        public IEnumerable GetAllFDaughters()
        {
            return _dataStore.Daughters.Select(d => d);
        }

        public Daughter GetDaughter(Guid id)
        {
            return _dataStore.Daughters.FirstOrDefault(d => d.Id == id);
        }

        public void AddDaughter(Daughter daughter)
        {
            _dataStore.Daughters.Add(daughter);
        }

        public void UpdateDaughter(Daughter daughter)
        {
            var oldFather = _dataStore.Daughters.FirstOrDefault(d => d.Id == daughter.Id);
            // Update each property
        }

        public void RemoveDaughter(Guid id)
        {
            _dataStore.Daughters.Remove(_dataStore.Daughters.FirstOrDefault(d => d.Id == id));
        }
    }
   
}
