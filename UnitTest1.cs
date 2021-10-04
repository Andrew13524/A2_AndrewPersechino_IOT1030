using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;

namespace ParticleMovementTester
{
    [TestClass]
    public class ParticleMovementTester
    {
        [TestMethod]
        public void TestMethod()
        {
            ParticleMovement pm1 = new ParticleMovement(5);

            pm1.MagneticField = false;
            pm1.GravitationalField = false;
                                                   // Movement Range = 5
            Assert.AreEqual(8, pm1.DistanceMoved); // Base movement only

            pm1.MagneticField = true;

            Assert.AreEqual(11, pm1.DistanceMoved); // Magnetic field is present

            pm1.MagneticField = false;
            pm1.GravitationalField = true;

            Assert.AreEqual(10, pm1.DistanceMoved); // Graviational field is present

            pm1.MagneticField = true;

            Assert.AreEqual(13, pm1.DistanceMoved); // Both are present

            pm1.MovementRange = -5;

            pm1.MagneticField = false;
            pm1.GravitationalField = false;
                                                    // Movement Range = -5
            Assert.AreEqual(-2, pm1.DistanceMoved); // Base movement only

            pm1.MagneticField = true;

            Assert.AreEqual(-5, pm1.DistanceMoved); // Magnetic field is present

            pm1.MagneticField = false;
            pm1.GravitationalField = true;

            Assert.AreEqual(0, pm1.DistanceMoved); // Graviational field is present

            pm1.MagneticField = true;

            Assert.AreEqual(-3, pm1.DistanceMoved); // Both are present

            pm1.MovementRange = 0;

            pm1.MagneticField = false;
            pm1.GravitationalField = false;
                                                   // Movement Range = 0
            Assert.AreEqual(3, pm1.DistanceMoved); // Base movement only

            pm1.MagneticField = true;

            Assert.AreEqual(3, pm1.DistanceMoved); // Magnetic field is present

            pm1.MagneticField = false;
            pm1.GravitationalField = true;

            Assert.AreEqual(5, pm1.DistanceMoved); // Graviational field is present

            pm1.MagneticField = true;

            Assert.AreEqual(5, pm1.DistanceMoved); // Both are present
        }
    }
}
