using System.Collections.Generic;
using UnityEngine;

    interface ICell
    {
        object Sex();
    }

    public class Vect2 {
        public int x;
        public int y;

        public Vect2(Vect2 v2)
        {
            x = v2.x;
            y = v2.y;
        }

        public Vect2() {
            x = 0;
            y = 0;
        }
        public Vect2(int x1, int y1)
        {
            x = x1;
            y = y1;
        }

        public override string ToString()
        {
            return "x:"+x.ToString() + ", y:" + y.ToString()+";";
        }
    }

    public class Cell
    {
        private int age_ = 1;
        private int sexCount = 0;
        private Cell mother, father;

        public Cell() {
        }


        public int GetAge(){
            return age_;
        }
        public void SetAge(int age){
            age_ = age;
        }

        public void IncAge()
        {
            age_++;
        }

        public bool isCanHaveSex()
        {
            if (sexCount < 2 && age_ > 5 && age_ < 12) return true;
            else return false;
        }

        public bool isCannotLifeAnymore() {
            if (age_ == 16 && sexCount == 2)
                return true;
            else return false;
        }

        public bool isHasRelationWith(Cell cell)
        {
            return true;
        }
    }

    public class Woman: Cell,ICell{
        public Woman()
        {
        }
        public object Sex(){
            return (object)this.GetType();//==typeof(Woman);
        }
    }


    public class Man: Cell,ICell{
        public Man()
        {

        }
        public object Sex(){
            return (object)this.GetType();// == typeof(Man);
        }
    }
