erDiagram
    PATIENT_TYPE {
        int patient_type_id PK
        varchar type_name
    }

    PATIENT {
        int patient_id PK
        varchar full_name
        varchar phone
        int patient_type_id FK
    }

    COVERAGE {
        int coverage_id PK
        int patient_id FK
        varchar insurance_company
        varchar policy_number
        int coverage_percentage
        varchar approval_status
    }

    SAMPLE {
        int sample_id PK
        int patient_id FK
        date collection_date
        varchar status
    }

    INVOICE {
        int invoice_id PK
        int patient_id FK
        int sample_id FK
        decimal total_amount
        varchar status
        datetime created_at
    }

    INVOICE_ITEM {
        int item_id PK
        int invoice_id FK
        int test_id FK
        decimal price
    }

    PAYMENT {
        int payment_id PK
        int invoice_id FK
        decimal amount
        varchar payment_method
        varchar payment_status
        datetime payment_date
    }

    FINANCIAL_LOG {
        int log_id PK
        int invoice_id FK
        int patient_id FK
        int sample_id FK
        varchar transaction_type
        decimal amount
        datetime created_at
    }

    TEST {
        int test_id PK
        varchar test_name
    }

    TEST_PRICE {
        int price_id PK
        int test_id FK
        int patient_type_id FK
        decimal price
    }

    %% العلاقات المبنية على الكاردينالية الموضحة بالرسم
    PATIENT_TYPE ||--o{ PATIENT : classifies
    PATIENT_TYPE ||--o{ TEST_PRICE : "defines price for"
    PATIENT ||--o| COVERAGE : "covered by"
    PATIENT ||--o{ SAMPLE : provides
    PATIENT ||--o{ INVOICE : "billed in"
    PATIENT ||--o{ FINANCIAL_LOG : "logged for"
    SAMPLE ||--|| INVOICE : "linked to"
    SAMPLE ||--|| FINANCIAL_LOG : "traced in"
    INVOICE ||--o{ INVOICE_ITEM : contains
    INVOICE ||--o| PAYMENT : "paid by"
    INVOICE ||--|| FINANCIAL_LOG : "recorded in"
    TEST ||--o{ TEST_PRICE : "priced by"
    TEST ||--o{ INVOICE_ITEM : "included in"