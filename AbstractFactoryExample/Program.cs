using System;

namespace AbstractFactoryPattern
{
    // Abstract Product A: Button
    public interface IButton
    {
        void Paint();
    }

    // Concrete Product A1: Windows Button
    public class WindowsButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a button in Windows style.");
        }
    }

    // Concrete Product A2: Mac Button
    public class MacButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a button in Mac style.");
        }
    }

    // Abstract Product B: Checkbox
    public interface ICheckbox
    {
        void Paint();
    }

    // Concrete Product B1: Windows Checkbox
    public class WindowsCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a checkbox in Windows style.");
        }
    }

    // Concrete Product B2: Mac Checkbox
    public class MacCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a checkbox in Mac style.");
        }
    }

    // Abstract Factory: GUI Factory
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    // Concrete Factory 1: Windows Factory
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox();
        }
    }

    // Concrete Factory 2: Mac Factory
    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }

    // Client class that uses the factories
    public class Application
    {
        private readonly IButton _button;
        private readonly ICheckbox _checkbox;

        // The client code works with factories through their abstract interface
        public Application(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
        }

        public void Render()
        {
            _button.Paint();
            _checkbox.Paint();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Simulating client decision based on operating system
            IGUIFactory factory;

            Console.WriteLine("Select operating system (windows/mac): ");
            string os = Console.ReadLine().ToLower();

            if (os == "windows")
            {
                factory = new WindowsFactory();
            }
            else if (os == "mac")
            {
                factory = new MacFactory();
            }
            else
            {
                throw new ArgumentException("Unsupported operating system.");
            }

            // Create and use application
            Application app = new Application(factory);
            app.Render();
        }
    }
}
