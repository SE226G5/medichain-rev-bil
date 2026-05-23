# توثيق المخططات الفنية (Technical Diagrams Documentation)

يحتوي هذا المستند على تحويل كامل وشامل للصور المرفقة الخاصة بـ **مخطط الفئات (Class Diagram)** و**مخطط علاقات الكيانات (ERD)** إلى أكواد **Mermaid** تفاعلية، بالإضافة إلى جداول توضيحية للمكونات والعلاقات لتسهيل استخدامها وتوثيقها داخل المشاريع البرمجية.

---

## 1. مخطط الفئات (Class Diagram)

يمثل هذا المخطط الهيكل البرمجي للنظام (Object-Oriented Design) ويشمل الفئات (Classes)، الخصائص (Attributes)، والعمليات (Methods)، بالإضافة إلى العلاقات المتنوعة بينها مثل الاعتمادية (Dependency) والارتباط (Association).

### كود ميرميد (Mermaid Code):

```mermaid
classDiagram
    class Patient {
        +int patientId
        +String fullName
        +String phone
        +int patientTypeId
        +getInvoices() List
        +updateInfo() void
    }

    class Coverage {
        +int coverageId
        +int patientId
        +String insuranceCompany
        +String policyNumber
        +int coveragePercentage
        +String approvalStatus
        +isValid() bool
        +validateCoverage() bool
        +calcCoveredAmount(amount) float
    }

    class BillingService {
        +createInvoice(patientId, sampleId) Invoice
        +applyPricing(invoice) void
        +processPayment(invoiceId, amount, method) Payment
        +validatePayment(invoiceId) bool
        +handleRejection(patientId) void
        +generateReport(dateFrom, dateTo) Report
    }

    class Sample {
        +int sampleId
        +int patientId
        +Date collectionDate
        +String status
    }

    class Invoice {
        +int invoiceId
        +int patientId
        +int sampleId
        +decimal totalAmount
        +String status
        +DateTime createdAt
        +calculateTotal() decimal
        +generateInvoice() void
        +isPaid() bool
    }

    class InvoiceItem {
        +int itemId
        +int invoiceId
        +int testId
        +decimal price
        +calcNet() decimal
    }

    class Payment {
        +int paymentId
        +int invoiceId
        +decimal amount
        +String paymentMethod
        +String paymentStatus
        +DateTime paymentDate
        +processPayment() bool
        +generateReceipt() void
        +reject() void
        +redirectToDirect() void
    }

    class FinancialLog {
        +int logId
        +int invoiceId
        +int patientId
        +int sampleId
        +String transactionType
        +decimal amount
        +DateTime createdAt
        +createLog() void
    }

    class Test {
        +int testId
        +String testName
        +getPriceForType(patientTypeId) float
    }

    class TestPrice {
        +int priceId
        +int testId
        +int patientTypeId
        +decimal price
    }

    class PatientType {
        +int patientTypeId
        +String typeName
        +getTestPrice(testId) float
    }

    %% العلاقات الموضحة في مخطط الفئات
    Patient "1" --> "0..1" Coverage : covered by
    Patient "1" --> "0..*" Sample : provides
    Patient "1" --> "0..*" Invoice : billed in
    PatientType "1" --> "0..*" TestPrice : defines
    Patient "1" --> "1" PatientType : has type
    BillingService ..> Invoice : creates / linked to
    BillingService ..> Payment : processes
    BillingService ..> FinancialLog : writes
    Sample "1" --> "0..1" Invoice : linked to
    Invoice "1" --> "1..*" InvoiceItem : contains
    Invoice "1" --> "0..1" Payment : paid by
    Invoice "1" --> "0..*" FinancialLog : recorded in
    InvoiceItem "1" --> "1" Test : refers to
    Test "1" --> "0..*" TestPrice : priced by
    FinancialLog --> Patient : logs for
    FinancialLog --> Sample : traces