--
-- PostgreSQL database dump
--

-- Dumped from database version 17.0
-- Dumped by pg_dump version 17.0

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: agreements; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.agreements (
    agreement_id integer NOT NULL,
    client_fullname character varying(100),
    client_phone_number character varying(16) NOT NULL,
    agreement_number character varying(20),
    agreement_date date,
    payment_date date,
    delivery_date date,
    summ numeric(10,2),
    CONSTRAINT agreements_client_phone_number_check CHECK ((((client_phone_number)::text ~ '^\+7\(\d{3}\)-\d{3}-\d{4}$'::text) OR ((client_phone_number)::text = 'не указан'::text)))
);


ALTER TABLE public.agreements OWNER TO postgres;

--
-- Name: agreements_agreement_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.agreements_agreement_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.agreements_agreement_id_seq OWNER TO postgres;

--
-- Name: agreements_agreement_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.agreements_agreement_id_seq OWNED BY public.agreements.agreement_id;


--
-- Name: drivers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.drivers (
    driver_id integer NOT NULL,
    driver_fullname character varying(100),
    phone_number character varying(16) NOT NULL,
    CONSTRAINT drivers_phone_number_check CHECK ((((phone_number)::text ~ '^\+7\(\d{3}\)-\d{3}-\d{4}$'::text) OR ((phone_number)::text = 'не указан'::text)))
);


ALTER TABLE public.drivers OWNER TO postgres;

--
-- Name: drivers_driver_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.drivers_driver_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.drivers_driver_id_seq OWNER TO postgres;

--
-- Name: drivers_driver_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.drivers_driver_id_seq OWNED BY public.drivers.driver_id;


--
-- Name: employees; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employees (
    employee_id integer NOT NULL,
    employee_fullname character varying(150),
    employee_birthdate date,
    employee_gender character(1),
    employee_post character varying(50),
    phone_number character varying(16) NOT NULL,
    login character varying(50),
    password character varying(50),
    CONSTRAINT employees_employee_gender_check CHECK ((employee_gender = ANY (ARRAY['м'::bpchar, 'ж'::bpchar]))),
    CONSTRAINT employees_phone_number_check CHECK ((((phone_number)::text ~ '^\+7\(\d{3}\)-\d{3}-\d{4}$'::text) OR ((phone_number)::text = 'не указан'::text)))
);


ALTER TABLE public.employees OWNER TO postgres;

--
-- Name: employees_employee_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.employees_employee_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.employees_employee_id_seq OWNER TO postgres;

--
-- Name: employees_employee_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.employees_employee_id_seq OWNED BY public.employees.employee_id;


--
-- Name: marks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.marks (
    mark_id integer NOT NULL,
    mark_name character varying(100),
    mark_type character varying(50),
    mark_tonn numeric(10,2),
    mark_lenght integer,
    mark_width integer,
    mark_height integer,
    state_number character varying(15),
    driver_id integer,
    status character varying(20) NOT NULL,
    CONSTRAINT marks_status_check CHECK (((status)::text = ANY ((ARRAY['свободен'::character varying, 'занят'::character varying, 'ремонт'::character varying])::text[])))
);


ALTER TABLE public.marks OWNER TO postgres;

--
-- Name: marks_mark_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.marks_mark_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.marks_mark_id_seq OWNER TO postgres;

--
-- Name: marks_mark_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.marks_mark_id_seq OWNED BY public.marks.mark_id;


--
-- Name: transportations; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.transportations (
    transportation_id integer NOT NULL,
    agreement_id integer,
    send_date date,
    arrive_date date,
    mark_id integer,
    send character varying(100),
    appointment character varying(100),
    employee_id integer,
    cargo character varying(100),
    cargo_type character varying(50),
    cargo_price numeric(10,2),
    best_before_date character varying(20),
    mass numeric(10,2)
);


ALTER TABLE public.transportations OWNER TO postgres;

--
-- Name: transportations_transportation_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.transportations_transportation_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.transportations_transportation_id_seq OWNER TO postgres;

--
-- Name: transportations_transportation_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.transportations_transportation_id_seq OWNED BY public.transportations.transportation_id;


--
-- Name: agreements agreement_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.agreements ALTER COLUMN agreement_id SET DEFAULT nextval('public.agreements_agreement_id_seq'::regclass);


--
-- Name: drivers driver_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.drivers ALTER COLUMN driver_id SET DEFAULT nextval('public.drivers_driver_id_seq'::regclass);


--
-- Name: employees employee_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees ALTER COLUMN employee_id SET DEFAULT nextval('public.employees_employee_id_seq'::regclass);


--
-- Name: marks mark_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.marks ALTER COLUMN mark_id SET DEFAULT nextval('public.marks_mark_id_seq'::regclass);


--
-- Name: transportations transportation_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportations ALTER COLUMN transportation_id SET DEFAULT nextval('public.transportations_transportation_id_seq'::regclass);


--
-- Data for Name: agreements; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.agreements (agreement_id, client_fullname, client_phone_number, agreement_number, agreement_date, payment_date, delivery_date, summ) FROM stdin;
1	Иванова Александра Ивановна	+7(493)-123-4567	15002	2024-12-01	2024-12-02	2024-12-10	20000.00
2	Петров Василий Петрович	+7(987)-123-5678	15003	2025-01-16	2025-01-16	2025-01-25	35000.00
3	Соловьев Андрей Николаевич	+7(812)-223-3200	15004	2025-02-03	2025-02-04	2025-02-18	48000.00
4	Воробьева Екатерина Валерьевна	+7(444)-222-3311	15005	2025-03-09	2025-03-10	2025-03-15	27000.00
5	Степанов Степан Сергеевич	+7(912)-888-3333	15006	2025-03-19	2025-03-20	2025-03-25	18000.00
6	Воробьева Екатерина Валерьевна	+7(444)-223-3311	15007	2025-03-15	2025-03-15	2025-03-18	22000.00
7	Воробьева Екатерина Валерьевна	+7(444)-222-3311	15008	2025-03-19	2025-03-19	2025-03-22	25000.00
\.


--
-- Data for Name: drivers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.drivers (driver_id, driver_fullname, phone_number) FROM stdin;
1	Злобин Клим Максимович	не указан
2	Аксенов Лев Тимурович	не указан
3	Семенов Андрей Родионович	не указан
4	Калмыков Лев Владиславович	не указан
5	Иванова Александра Ивановна	+7(493)-123-4567
6	Петров Василий Петрович	+7(987)-123-5678
7	Соловьев Андрей Николаевич	+7(812)-223-3200
8	Воробьева Екатерина Валерьевна	+7(444)-222-3311
9	Степанов Степан Сергеевич	+7(912)-888-3333
\.


--
-- Data for Name: employees; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employees (employee_id, employee_fullname, employee_birthdate, employee_gender, employee_post, phone_number, login, password) FROM stdin;
1	Бессмертный Кощей Спиридонович	1960-03-14	м	директор	+7(999)-888-8888	кощей	1
2	Царевич Иван Иванович	1985-06-30	м	администратор	+7(888)-999-9999	adm	adm
3	Премудрая Василиса Егоровна	1999-09-09	ж	менеджер	+7(888)-777-7777	Премудрая	111
4	Болотная Кикимора Аристарховна	1980-05-18	ж	менеджер	+7(888)-777-7778	Бол	2
5	Богатырев Добрыня Никитич	1995-11-24	м	менеджер	+7(888)-777-7779	Богат	2
6	Пилипенко Максим Владимирович	2006-12-06	м	администратор	+7(951)-537-2747	none	none
\.


--
-- Data for Name: marks; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.marks (mark_id, mark_name, mark_type, mark_tonn, mark_lenght, mark_width, mark_height, state_number, driver_id, status) FROM stdin;
1	Dongfeng Z55N	Рефрижератор	3.00	5860	2016	2354	А010АА	1	свободен
2	Dongfeng C100M	Рефрижератор	6.80	7920	2236	2460	Е287ТН	2	свободен
3	Iveco 140E Ksa-kori +PL	Закрытый кузов	8.00	7600	2480	2500	П614ТК	3	свободен
4	JAC N90	Закрытый кузов	5.80	7400	2550	2500	Д211СР	4	свободен
\.


--
-- Data for Name: transportations; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.transportations (transportation_id, agreement_id, send_date, arrive_date, mark_id, send, appointment, employee_id, cargo, cargo_type, cargo_price, best_before_date, mass) FROM stdin;
1	1	2024-12-07	2024-12-10	3	Ростов-на-Дону	Казань, Татарстан, Россия	4	Хозтовары	непродовольственный	250000.00	10.2026	2.20
2	2	2025-01-20	2025-01-25	4	Ростов-на-Дону	Усмань, Липецкая область, Россия	5	Ламинат	стройматериалы	315000.00	неогр.	5.00
3	3	2025-02-15	2025-02-18	3	Ростов-на-Дону	Барнаул, Алтайский край, Россия	5	Доски	стройматериалы	289000.00	неогр.	7.00
4	4	2025-03-15	2025-03-15	1	Ростовская область, Азовский район, село Пешково	Ростов-на-Дону	3	овощи	продовольственный	200000.00	04.2025	1.50
5	5	2025-03-24	2025-03-25	2	Ростовская область, г.Азов	Ростов-на-Дону	4	Молочные \nи кондитерские изделия	продовольственный	156000.00	28.03.2025	2.50
6	6	2025-03-18	2025-03-18	2	Ростовская область, Азовский район, село Пешково	Ростов-на-Дону	3	овощи	продовольственный	200000.00	04.2025	2.20
7	7	2025-03-22	2025-03-22	1	Ростовская область, Азовский район, село Пешково	Ростов-на-Дону	3	овощи	продовольственный	200000.00	04.2025	1.80
\.


--
-- Name: agreements_agreement_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.agreements_agreement_id_seq', 7, true);


--
-- Name: drivers_driver_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.drivers_driver_id_seq', 9, true);


--
-- Name: employees_employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employees_employee_id_seq', 6, true);


--
-- Name: marks_mark_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.marks_mark_id_seq', 4, true);


--
-- Name: transportations_transportation_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.transportations_transportation_id_seq', 7, true);


--
-- Name: agreements agreements_agreement_number_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.agreements
    ADD CONSTRAINT agreements_agreement_number_key UNIQUE (agreement_number);


--
-- Name: agreements agreements_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.agreements
    ADD CONSTRAINT agreements_pkey PRIMARY KEY (agreement_id);


--
-- Name: drivers drivers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.drivers
    ADD CONSTRAINT drivers_pkey PRIMARY KEY (driver_id);


--
-- Name: employees employees_login_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees
    ADD CONSTRAINT employees_login_key UNIQUE (login);


--
-- Name: employees employees_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees
    ADD CONSTRAINT employees_pkey PRIMARY KEY (employee_id);


--
-- Name: marks marks_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.marks
    ADD CONSTRAINT marks_pkey PRIMARY KEY (mark_id);


--
-- Name: marks marks_state_number_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.marks
    ADD CONSTRAINT marks_state_number_key UNIQUE (state_number);


--
-- Name: transportations transportations_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportations
    ADD CONSTRAINT transportations_pkey PRIMARY KEY (transportation_id);


--
-- Name: marks marks_driver_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.marks
    ADD CONSTRAINT marks_driver_id_fkey FOREIGN KEY (driver_id) REFERENCES public.drivers(driver_id);


--
-- Name: transportations transportations_agreement_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportations
    ADD CONSTRAINT transportations_agreement_id_fkey FOREIGN KEY (agreement_id) REFERENCES public.agreements(agreement_id);


--
-- Name: transportations transportations_employee_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportations
    ADD CONSTRAINT transportations_employee_id_fkey FOREIGN KEY (employee_id) REFERENCES public.employees(employee_id);


--
-- Name: transportations transportations_mark_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportations
    ADD CONSTRAINT transportations_mark_id_fkey FOREIGN KEY (mark_id) REFERENCES public.marks(mark_id);


--
-- PostgreSQL database dump complete
--

