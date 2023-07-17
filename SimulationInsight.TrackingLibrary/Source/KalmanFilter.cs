using SimulationInsight.MathLibrary;

using static SimulationInsight.MathLibrary.Matrix;

namespace SimulationInsight.TrackingLibrary;

public abstract class KalmanFilterBase : IKalmanFilter
{
    public int NumberOfStates { get; set; }

    public double LastUpdateTime { get; set; }

    public Vector X { get; set; }

    public Matrix P { get; set; }

    public Matrix Phi { get; set; }

    public Matrix Q { get; set; }

    public Vector XPred { get; set; }

    public Matrix PPred { get; set; }

    public Vector Z { get; set; }

    public Matrix R { get; set; }

    public Vector ZPred { get; set; }

    public Matrix H { get; set; }

    public Vector Y { get; set; }

    public Matrix S { get; set; }

    public Matrix K { get; set; }

    public void Initalise(double time, Vector x, Matrix P)
    {
        LastUpdateTime = time;
        X = x;
        this.P = P;
    }

    public void Update(double time, Vector z, Matrix R)
    {
        Z = z;
        this.R = R;

        var deltaTime = time - LastUpdateTime;

        Phi = StateTransitionMatrix(deltaTime);
        Q = ProcessNoiseMatrix(deltaTime);

        XPred = Phi * X;
        PPred = Phi * P * Phi.Transpose() + Q;

        ZPred = MeasurementVector(XPred);
        H = MeasurementMatrix(XPred);

        Y = Z - ZPred;
        S = H * PPred * H.Transpose() + R;

        K = P * H.Transpose() * S.Inverse();

        X = XPred + K * Y;
        P = (IdentityMatrix(NumberOfStates) - K * H) * PPred;
    }

    public (Vector XPred, Matrix PPred) Predict(double time)
    {
        var dt = time - LastUpdateTime;

        Phi = StateTransitionMatrix(dt);
        Q = ProcessNoiseMatrix(dt);

        var XPred = Phi * X;
        var PPred = Phi * P * Phi.Transpose() + Q;

        return (XPred, PPred);
    }

    public abstract Matrix StateTransitionMatrix(double dt);

    public abstract Matrix ProcessNoiseMatrix(double dt);

    public abstract Vector MeasurementVector(Vector xPred);

    public abstract Matrix MeasurementMatrix(Vector xPred);
}