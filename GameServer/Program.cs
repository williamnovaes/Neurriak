using System;
using System.Threading;

namespace NeurriakWorldServer {
    class Program {

    	private static bool isRunning = false;

        static void Main(string[] args) {
            Console.Title = "Neurriak Server";

            isRunning = true;
            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();
            Server.Start(10, 26950);
        }

        private static void MainThread() {
        	Console.WriteLine($"Main Thread started. Running at {Constants.TICKS_PER_SEC} ticks per second.");
			// long lastTick = DateUtil.CurrentTimeNano();
			// double delta = 0;
			// long now = 0;
			// int frames = 0;
			// long timer = DateUtil.CurrentTimeMillis();

        	DateTime _nextLoop = DateTime.Now;
        	while (isRunning) {
        		while (_nextLoop < DateTime.Now) {
        			GameLogic.Update();

        			_nextLoop = _nextLoop.AddMilliseconds(Constants.MS_PER_TICK);
        			if (_nextLoop > DateTime.Now) {
        				Thread.Sleep(_nextLoop - DateTime.Now);
        			}
        		}
        	}

			// while (isRunning) {
			// 	now = DateUtil.CurrentTimeNano();
			// 	delta += (now - lastTick) / Constants.MS_PER_TICK;
			// 	lastTick = now;
			// 	if (delta >= 1) {
			// 		GameLogic.Update();
			// 		delta--;
			// 		frames++;
			// 	}
				
			// 	if (DateUtil.CurrentTimeMillis() - timer >= 1000) {
			// 		Console.WriteLine($"FPS: {frames}");
			// 		frames = 0;
			// 		timer += 1000;
			// 	}
			// }
        }
    }
}