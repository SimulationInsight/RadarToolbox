using SimulationInsight.MathLibrary;
using static System.Math;
using static SimulationInsight.MathLibrary.Matrix;

namespace SimulationInsight.TrackingLibrary;

public class KalmanFilterConstantVelocity6State : KalmanFilterBase
{
    public Vector QSd
    {
        get; set;
    }

    public KalmanFilterConstantVelocity6State()
    {
        NumberOfStates = 6;
        QSd = new Vector(3);
    }

    public override Matrix StateTransitionMatrix(double dt)
    {
        Phi = IdentityMatrix(6, 6);

        Phi[0, 3] = dt;
        Phi[1, 4] = dt;
        Phi[2, 5] = dt;

        return Q;
    }

    public override Matrix ProcessNoiseMatrix(double dt)
    {
        Q = new Matrix(6, 6);

        var QVar = QSd * QSd;

        Q[0, 0] = Pow(dt, 3.0) / 2.0 * QVar[0];
        Q[0, 3] = dt * dt / 2.0 * QVar[0];
        Q[3, 0] = Q[0, 3];
        Q[3, 3] = dt * QVar[0];

        Q[1, 1] = Pow(dt, 3.0) / 2.0 * QVar[1];
        Q[1, 4] = dt * dt / 2.0 * QVar[1];
        Q[4, 1] = Q[1, 4];
        Q[4, 4] = dt * QVar[1];

        Q[2, 2] = Pow(dt, 3.0) / 2.0 * QVar[2];
        Q[2, 5] = dt * dt / 2.0 * QVar[2];
        Q[5, 2] = Q[2, 5];
        Q[5, 5] = dt * QVar[2];

        return Q;
    }

    public override Vector MeasurementVector(Vector xPred)
    {
        var Z = new Vector(3);

        return Z;
    }

    public override Matrix MeasurementMatrix(Vector xPred)
    {
        var H = new Matrix(3, 6);

        return H;
    }
}