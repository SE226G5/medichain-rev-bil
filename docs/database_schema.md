## 1. Entity-Relationship Diagram (ERD)

[Insert ERD Diagram Screenshot Here]

## 2. Tables List

| Table Name | Purpose / Description |
| :--- | :--- |
| PATIENT_TYPE | Stores patient categories used for pricing and classification. |
| PATIENT | Stores patient information including name, phone number, and type. |
| COVERAGE | Stores insurance coverage information and approval status for patients. |
| SAMPLE | Stores laboratory samples collected from patients. |
| TEST | Stores available laboratory tests. |
| TEST_PRICE | Stores test pricing based on patient type. |
| INVOICE | Stores billing invoices generated for patients. |
| INVOICE_ITEM | Stores individual test items included in invoices. |
| PAYMENT | Stores payment transactions and payment status. |
| FINANCIAL_LOG | Stores financial transactions and audit records. |

## 3. Shared Data (Integration Points)

### Shared Table/ID: patient_id
* Shared With: Patient Management Module
* Purpose: Identifies patients across all laboratory and billing processes.

### Shared Table/ID: sample_id
* Shared With: Sample Collection Module
* Purpose: Links collected samples to invoices and financial records.

### Shared Table/ID: test_id
* Shared With: Laboratory Testing Module
* Purpose: Identifies laboratory tests used in billing calculations.

### Shared Table/ID: invoice_id
* Shared With: Reporting & Analytics Module
* Purpose: Provides billing and revenue information for reporting.

### Shared Table/ID: payment_id
* Shared With: Reporting & Analytics Module
* Purpose: Tracks payment transactions and financial performance.
