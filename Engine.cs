namespace rgn
{
   public class Engine
    {
        public float rpm { get; set; }
        public float idleRpm { get; init; }
        public float maxRpm { get; init; }
        public float inertia { get; init; }
        float throttle;
        public float outputTorque { get; set; }

        
       public Engine()
        {
            rpm = idleRpm;
            throttle = 0.0f;
            outputTorque = 0.0f;
        }

        float GetTorque(float rpm)
        {
            if (rpm < 1000) return 100;
            if (rpm < 3000) return 200;
            if (rpm < 5000) return 180;
            if (rpm < 6500) return 150;

            return 100;

        }
        
       public void Update(float dt, float throttle)
        {
            float maxTorque = GetTorque(rpm);

            

            throttle = Maths.Clamp(throttle, 0.0f, 1.0f);
            
            float engineTorque = maxTorque * throttle;
            rpm += (engineTorque / inertia) * dt;
            rpm = Maths.Clamp(rpm, idleRpm, maxRpm);
            outputTorque = engineTorque;
        }
    }
}