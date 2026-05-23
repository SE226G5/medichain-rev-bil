# Revenue & Billing Module Diagrams

## 1. Use Case Diagram

flowchart LR
    Receptionist[Receptionist] --> CreateInvoice((Create Invoice))
    Receptionist --> ProcessPayment((Process Payment))
    Receptionist --> ViewInvoiceStatus((View Invoice Status))
    Receptionist --> VerifyInsurance((Verify Insurance))

    Accountant[Accountant] --> GenerateReports((Generate Billing Reports))
    Accountant --> ViewLogs((View Financial Logs))

    LabStaff[Lab Staff] --> CheckPaymentStatus((Check Payment Status))
    Admin[Admin] --> ManageSettings((Manage Billing Settings))

    InsuranceSystem[Insurance System] --> VerifyInsurance
    ProcessPayment -. include .-> VerifyInsurance
## 2. Activity Diagram

flowchart TD
    Start([Start]) --> A[Select Patient]
    A --> B[Create Invoice]
    B --> C[Check Insurance Coverage]
    C --> D{Insurance Approved?}

    D -- Yes --> E[Calculate Discount]
    D -- No --> F[Use Direct Payment]

    E --> G[Process Payment]
    F --> G

    G --> H{Payment Successful?}

    H -- Yes --> I[Update Invoice Status]
    I --> J[Allow Result Approval]

    H -- No --> K[Reject or Retry Payment]

    J --> End([End])
    K --> End
## 3. Sequence Diagram

sequenceDiagram
    actor Receptionist
    participant BillingSystem as Billing System
    participant InsuranceSystem as Insurance System
    participant PaymentService as Payment Service
    participant Database

    Receptionist->>BillingSystem: Create Invoice
    BillingSystem->>Database: Fetch Patient Data
    Database-->>BillingSystem: Patient Information

    BillingSystem->>InsuranceSystem: Verify Insurance Coverage
    InsuranceSystem-->>BillingSystem: Coverage Approved / Rejected

    alt Insurance Approved
        BillingSystem->>BillingSystem: Calculate Discount
    else No Insurance
        BillingSystem->>BillingSystem: Use Full Payment
    end

    Receptionist->>BillingSystem: Confirm Payment
    BillingSystem->>PaymentService: Process Payment
    PaymentService-->>BillingSystem: Payment Success / Failed

    alt Payment Successful
        BillingSystem->>Database: Save Payment Record
        BillingSystem->>Database: Update Invoice Status
        BillingSystem-->>Receptionist: Generate Receipt
        BillingSystem-->>Receptionist: Allow Result Approval
    else Payment Failed
        BillingSystem-->>Receptionist: Retry Payment
    end