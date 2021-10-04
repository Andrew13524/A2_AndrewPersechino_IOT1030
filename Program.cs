using System;

namespace A2
{
	class Program
	{
		private static int movementRange;
		private static int GetMovementRange()
        {
			Random random = new Random(1);
			return movementRange = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
		}
		static void Main(string[] args)
		{
			ParticleMovement particleMover = new ParticleMovement(GetMovementRange());
			while (true)
			{
				Console.Write("0 for base movement only\n1 if a magnetic field is present\n" +
							  "2 if a gravitational field is present\n3 for both fields\n");
				char key = Console.ReadKey().KeyChar;
				if (key != '0' && key != '1' && key != '2' && key != '3') return;
				particleMover.MagneticField = key == '1' || key == '3';
				particleMover.GravitationalField = key == '2' || key == '3';
				Console.WriteLine($"\nParticle with a movement range of {movementRange} units" +
								  $" moved a total distance of {particleMover.DistanceMoved} units.\n");
			}
		}
	}

	public class ParticleMovement
	{
		/// <summary>
		/// Base movement of the particle
		/// </summary>
		public const int BASE_MOVEMENT = 3;
		/// <summary>
		/// Units traveled when particle is affected by gravity
		/// </summary>
		public const int GRAVITY_MOVEMENT = 2;
		/// <summary>
		/// Units of distance
		/// </summary>
		public int Distance { get; private set; }
		/// <summary>
		/// Indicates how many units the particle moved
		/// </summary>
		public int DistanceMoved;

		private int movementRange;
		private bool gravitationalField;
		private bool magneticField;

		/// <summary>
		/// Determines the movement range of the particle
		/// </summary>
		public int MovementRange
		{
			get => movementRange;
			set
			{
				movementRange = value;
				CalculateDistance();
			}
		}
		/// <summary>
		/// True if gravitational field is present
		/// </summary>
		public bool GravitationalField
		{
			get => gravitationalField;
			set 
			{
				gravitationalField = value;
				CalculateDistance();
			}
		}
		/// <summary>
		/// True if magnetic field is present
		/// </summary>
		public bool MagneticField
        {
			get => magneticField;
            set
            {
				magneticField = value;
				CalculateDistance();
            }
        }
		/// <summary>
		/// Sets the movement range value
		/// </summary>
		/// <param name="movementRange"></param>
		public ParticleMovement(int movementRange)
        {
			MovementRange = movementRange;
        }

		private void CalculateDistance()
		{
			decimal MagneticMultiplier = MagneticField ? 1.75M : 1M;
			int GravityMovement = GravitationalField ? GRAVITY_MOVEMENT : 0;
			DistanceMoved = (int)(MovementRange * MagneticMultiplier) + BASE_MOVEMENT + GravityMovement;
		}
	}
}
