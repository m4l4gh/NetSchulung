using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ShowKapselung
    {
        public void TestA()
        {

        }

        private void TestB()
        {

        }

        internal void TestC()
        {

        }
    }

    public class Parent
    {
        protected void ParentMethodA()
        {

        }
        private void ParentMethodB()
        {

        }
        public void ParentMethodC()
        {

        }
    }

    public class Child : Parent
    {
        public Child()
        {
            ParentMethodA();
            ParentMethodC();
        }
    }

    public abstract class ParentAbstract
    {
        abstract public void ParentMethodC();
        virtual public void ParentMethodD()
        {

        }
    }

    public class ChildOfAbstr : ParentAbstract
    {
        public override void ParentMethodC()
        {
            throw new NotImplementedException();
        }
        public override void ParentMethodD()
        {
            base.ParentMethodD();
            this.ParentMethodC();
            // Eigene Logik this.
        }

    }

    public class ChildComposite
    {
        readonly private Parent _parent = new Parent();
        public void ParentMethodC()
        {
            _parent.ParentMethodC();
        }
    }

    public class ChildShadowing : Parent
    {
        public new void ParentMethodA()
        {

        }
    }

    public class Parent2 : IParent2
    {
        public void ParentMethodE() { }

    }

    public class ChildMulti : Parent, IParent2
    {
        public void ParentMethodE()
        {
            new Parent2().ParentMethodE();
        }
    }
}
