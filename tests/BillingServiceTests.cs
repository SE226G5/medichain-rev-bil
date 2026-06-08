using Xunit;
using MathLibrary;

namespace MathLibrary.Tests;

public class BillingServiceTests
{
    private readonly BillingService _service = new BillingService();

    [Fact]
    public void CalculateBill_VIPPatientCash_ReturnsDiscount()
    {
        // Arrange
        string patientType = "VIP";
        string paymentMethod = "Cash";
        double amount = 1000;

        // Act
        double result = _service.CalculateBill(patientType, paymentMethod, amount, false);

        // Assert
        Assert.Equal(800, result);
    }

    [Fact]
    public void CalculateBill_RegularPatientCash_ReturnsFullAmount()
    {
        // Arrange
        string patientType = "Regular";
        string paymentMethod = "Cash";
        double amount = 500;

        // Act
        double result = _service.CalculateBill(patientType, paymentMethod, amount, false);

        // Assert
        Assert.Equal(500, result);
    }

    [Fact]
    public void CalculateBill_EmergencyPatientCash_ReturnsSurcharge()
    {
        // Arrange
        string patientType = "Emergency";
        string paymentMethod = "Cash";
        double amount = 1000;

        // Act
        double result = _service.CalculateBill(patientType, paymentMethod, amount, false);

        // Assert
        Assert.Equal(1200, result);
    }

    [Fact]
    public void CalculateBill_VIPPatientInsuranceApproved_ReturnsHalfDiscount()
    {
        // Arrange
        string patientType = "VIP";
        string paymentMethod = "Insurance";
        double amount = 1000;

        // Act
        double result = _service.CalculateBill(patientType, paymentMethod, amount, true);

        // Assert
        Assert.Equal(400, result);
    }

    [Fact]
    public void CalculateBill_InvalidPatientType_ThrowsException()
    {
        // Arrange
        string patientType = "Unknown";
        string paymentMethod = "Cash";
        double amount = 1000;

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            _service.CalculateBill(patientType, paymentMethod, amount, false));
    }

    [Fact]
    public void CalculateBill_InsuranceNotApproved_ThrowsException()
    {
        // Arrange
        string patientType = "Regular";
        string paymentMethod = "Insurance";
        double amount = 500;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            _service.CalculateBill(patientType, paymentMethod, amount, false));
    }
}