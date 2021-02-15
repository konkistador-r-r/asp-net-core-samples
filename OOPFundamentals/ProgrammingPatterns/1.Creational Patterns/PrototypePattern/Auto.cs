using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

/* В рассматриваемом случае у машинки есть три параметра: ее скорость, 
 * идентификационный номер модели и возраст ребенка, начиная с которого он может начать играть с ней. 
 * Все они представлены в цифровом виде, а значит, можно сделать поверхностную копию объекта 
 * с помощью метода MemberwiseClone. При этом сначала создается новый объект, а затем в него 
 * копируются нестатические поля текущего объекта. 
 * Значимые типы (которые и использованы в выбранном примере) копируются побитово, 
 * ссылочные же не клонируются, а просто копируются ссылки на те же объекты (это нужно учитывать, 
 * чтобы не внести путаницу в архитектуру программы). Получается, что ссылочные типы могут указывать 
 * на один и тот же объект, а это, естественно, нежелательно, 
 * и потому MemberwiseClone может вам и не подойти.
 */
namespace PrototypePattern
{
    // Абстрактный класс служащий основой для конкретных реализаций
    [Serializable]
    abstract class Auto
    {
        private int _modelId;
        private StringBuilder _maxSpeed = new StringBuilder();
        private int _yearsOld;

        protected Auto(int modelId, object maxSpeed, int yearsOld)
        {
            _modelId = modelId;
            _maxSpeed.Append(maxSpeed);
            _yearsOld = yearsOld;
        }

        public int ModelId
        {
            get { return _modelId; }
        }

        public object MaxSpeed
        {
            get { return _maxSpeed.ToString(); }
            set { _maxSpeed.Append(value); }
        }

        public int YearsOld
        {
            get { return _yearsOld; }
        }

        public abstract Auto Clone();
    }

    // Реализация конкретного автомобиля 1
    [Serializable]
    internal class AutoConrete1 : Auto
    {
        public AutoConrete1(int modelId, object maxSpeed, int yearsOld) : base(modelId, maxSpeed, yearsOld)
        {
        }

        public override Auto Clone()
        {
            return MemberwiseClone() as Auto;
        }
    }

    // Реализация конкретного автомобиля 2
    [Serializable]
    internal class AutoConrete2 : Auto
    {
        public AutoConrete2(int modelId, int maxSpeed, int yearsOld)
            : base(modelId, maxSpeed, yearsOld)
        {
        }

        public override Auto Clone()
        {
            return MemberwiseClone() as Auto;
            /*
             * The MemberwiseClone method creates a shallow copy by creating a new object, and then copying the nonstatic fields of the current object 
             * to the new object. If a field is a value type, a bit-by-bit copy of the field is performed. 
             * Note: If a field is a reference type, the reference is copied but the referred object is not; therefore, 
             * Note: the original object and its clone refer to the same object.
             */
        }
    }  
}
