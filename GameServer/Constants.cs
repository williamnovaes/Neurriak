using System;

namespace NeurriakWorldServer {
	public class Constants {
		public const int TICKS_PER_SEC = 30;
		public const double NS_PER_TICK = 1000000000 / TICKS_PER_SEC;
		public const double MS_PER_TICK = 1000 / TICKS_PER_SEC;
	}
}