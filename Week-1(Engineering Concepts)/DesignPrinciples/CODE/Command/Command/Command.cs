using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    interface ICommand
    {
        void Execute();
    }

    class Light
    {
        public void On() => Console.WriteLine("Light turned ON");
        public void Off() => Console.WriteLine("Light turned OFF");
    }

    class LightOnCommand : ICommand
    {
        private Light light;
        public LightOnCommand(Light light) => this.light = light;
        public void Execute() => light.On();
    }

    class LightOffCommand : ICommand
    {
        private Light light;
        public LightOffCommand(Light light) => this.light = light;
        public void Execute() => light.Off();
    }

    class RemoteControl
    {
        private ICommand command;
        public void SetCommand(ICommand command) => this.command = command;
        public void PressButton() => command.Execute();
    }

    class Command
    {
        static void Main(string[] args)
        {
            var light = new Light();
            var remote = new RemoteControl();

            remote.SetCommand(new LightOnCommand(light));
            remote.PressButton();

            remote.SetCommand(new LightOffCommand(light));
            remote.PressButton();
        }
    }
}