## 1. Overview
The Revenue & Billing (REV-BIL) module manages laboratory billing, invoice generation, payment processing, insurance coverage handling, and financial transaction logging. It communicates with patient, sample, and laboratory testing modules to calculate charges and maintain billing records.

## 2. Main Endpoints

### Endpoint 1: Create Invoice
* Method: POST
* What it does: Creates a new invoice for a patient's laboratory services.
* Required Data:
  * patient_id
  * sample_id
  * test_id(s)
* Returned Data:
  * invoice_id
  * total_amount
  * status
  * created_at

### Endpoint 2: Get Invoice Details
* Method: GET
* What it does: Retrieves invoice information and included tests.
* Required Data:
  * invoice_id
* Returned Data:
  * Invoice Information
  * Patient Information
  * Invoice Items
  * Total Amount
  * Payment Status

### Endpoint 3: Record Payment
* Method: POST
* What it does: Records a payment for an invoice.
* Required Data:
  * invoice_id
  * amount
  * payment_method
* Returned Data:
  * payment_id
  * payment_status
  * payment_date

### Endpoint 4: Get Patient Billing History
* Method: GET
* What it does: Returns all invoices and payments for a patient.
* Required Data:
  * patient_id
* Returned Data:
  * Invoice List
  * Payment Records
  * Outstanding Balances

### Endpoint 5: Get Test Pricing
* Method: GET
* What it does: Retrieves the price of a laboratory test based on patient type.
* Required Data:
  * test_id
  * patient_type_id
* Returned Data:
  * test_name
  * patient_type
  * price

### Endpoint 6: Log Financial Transaction
* Method: POST
* What it does: Stores financial transaction records in the audit log.
* Required Data:
  * invoice_id
  * patient_id
  * sample_id
  * transaction_type
  * amount
* Returned Data:
  * log_id
  * created_at
