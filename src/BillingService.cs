namespace MathLibrary;

public class BillingService
{
    private static readonly Dictionary<string, double> PatientMultipliers = new()
    {
        { "VIP", 0.8 },
        { "Regular", 1.0 },
        { "Emergency", 1.2 }
    };

    public double CalculateBill(string patientType, string paymentMethod,
                                double amount, bool insuranceApproved)
    {
        double afterPatientDiscount = ApplyPatientDiscount(patientType, amount);
        double finalAmount = ApplyPaymentMethod(paymentMethod, afterPatientDiscount, insuranceApproved);

        if (finalAmount <= 0)
            throw new ArgumentException("Amount must be positive");

        return finalAmount;
    }

    private double ApplyPatientDiscount(string patientType, double amount)
    {
        if (!PatientMultipliers.ContainsKey(patientType))
            throw new ArgumentException("Invalid patient type");
        return amount * PatientMultipliers[patientType];
    }

    private double ApplyPaymentMethod(string paymentMethod, double amount, bool insuranceApproved)
    {
        if (paymentMethod == "Insurance")
        {
            if (!insuranceApproved)
                throw new InvalidOperationException("Insurance not approved");
            return amount * 0.5;
        }
        if (paymentMethod == "Cash")
            return amount;
        throw new ArgumentException("Invalid payment method");
    }
}