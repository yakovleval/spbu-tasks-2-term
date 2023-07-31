using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public delegate void ArrowHandler();
namespace task2
{
    public class UpdateViewEventArgs : EventArgs
    {
        private readonly bool updateView;
        public UpdateViewEventArgs(bool updateView = true) => this.updateView = updateView;
        public bool UpdateView => updateView;
    }
    public class EventLoop
    {
        public event EventHandler<UpdateViewEventArgs> LeftHandler = (sender, args) => { };
        public event EventHandler<UpdateViewEventArgs> RightHandler = (sender, args) => { };
        public event EventHandler<UpdateViewEventArgs> UpHandler = (sender, args) => { };
        public event EventHandler<UpdateViewEventArgs> DownHandler = (sender, args) => { };
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftHandler(this, new UpdateViewEventArgs());
                        break;
                    case ConsoleKey.RightArrow:
                        RightHandler(this, new UpdateViewEventArgs());
                        break;
                    case ConsoleKey.UpArrow:
                        UpHandler(this, new UpdateViewEventArgs());
                        break;
                    case ConsoleKey.DownArrow:
                        DownHandler(this, new UpdateViewEventArgs());
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
