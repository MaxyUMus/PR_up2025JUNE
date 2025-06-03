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

--
-- Name: status_enum; Type: TYPE; Schema: public; Owner: postgres
--

CREATE TYPE public.status_enum AS ENUM (
    'новый',
    'просмотрен',
    'на рассмотрении',
    'на оформлении',
    'продан'
);


ALTER TYPE public.status_enum OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: clients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.clients (
    client_id integer NOT NULL,
    client_name character varying(150),
    client_birthdate date,
    client_phone character varying(20)
);


ALTER TABLE public.clients OWNER TO postgres;

--
-- Name: clients_client_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.clients_client_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.clients_client_id_seq OWNER TO postgres;

--
-- Name: clients_client_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.clients_client_id_seq OWNED BY public.clients.client_id;


--
-- Name: employees; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employees (
    employee_id integer NOT NULL,
    employee_name character varying(100),
    employee_birthdate date,
    employee_phone character varying(20),
    login character varying(100),
    password character varying(100)
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
-- Name: objects; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.objects (
    object_id integer NOT NULL,
    object_status public.status_enum,
    square character varying(100),
    room_count integer,
    object_address character varying(100),
    construction_year integer,
    district character varying(100),
    floor integer,
    price numeric,
    property_type character varying(100),
    owner_name character varying(150),
    phone character varying(20),
    registration_date date
);


ALTER TABLE public.objects OWNER TO postgres;

--
-- Name: objects_object_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.objects_object_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.objects_object_id_seq OWNER TO postgres;

--
-- Name: objects_object_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.objects_object_id_seq OWNED BY public.objects.object_id;


--
-- Name: purchase_orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.purchase_orders (
    purchase_order_id integer NOT NULL,
    square character varying(100),
    room_cnt integer,
    year integer,
    district character varying(100),
    floor integer,
    price integer,
    type character varying(100),
    client_id integer,
    order_date date
);


ALTER TABLE public.purchase_orders OWNER TO postgres;

--
-- Name: purchase_orders_purchase_order_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.purchase_orders_purchase_order_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.purchase_orders_purchase_order_id_seq OWNER TO postgres;

--
-- Name: purchase_orders_purchase_order_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.purchase_orders_purchase_order_id_seq OWNED BY public.purchase_orders.purchase_order_id;


--
-- Name: sale_applications; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sale_applications (
    sale_application_id integer NOT NULL,
    object_id integer,
    client_id integer
);


ALTER TABLE public.sale_applications OWNER TO postgres;

--
-- Name: sale_applications_sale_application_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sale_applications_sale_application_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sale_applications_sale_application_id_seq OWNER TO postgres;

--
-- Name: sale_applications_sale_application_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sale_applications_sale_application_id_seq OWNED BY public.sale_applications.sale_application_id;


--
-- Name: clients client_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clients ALTER COLUMN client_id SET DEFAULT nextval('public.clients_client_id_seq'::regclass);


--
-- Name: employees employee_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees ALTER COLUMN employee_id SET DEFAULT nextval('public.employees_employee_id_seq'::regclass);


--
-- Name: objects object_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.objects ALTER COLUMN object_id SET DEFAULT nextval('public.objects_object_id_seq'::regclass);


--
-- Name: purchase_orders purchase_order_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchase_orders ALTER COLUMN purchase_order_id SET DEFAULT nextval('public.purchase_orders_purchase_order_id_seq'::regclass);


--
-- Name: sale_applications sale_application_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sale_applications ALTER COLUMN sale_application_id SET DEFAULT nextval('public.sale_applications_sale_application_id_seq'::regclass);


--
-- Data for Name: clients; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.clients (client_id, client_name, client_birthdate, client_phone) FROM stdin;
1	Коржиков Андрей Иванович	2003-07-01	+7(999)999-1919
2	Заболотский Николай Алексеевич	2005-04-09	+7(928)892-9929
3	Скитальцев Валерий Владимирович	2001-11-04	+7(909)429-4994
\.


--
-- Data for Name: employees; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employees (employee_id, employee_name, employee_birthdate, employee_phone, login, password) FROM stdin;
2	Нел Владислав Максимович	2001-01-01		none	none
1	Гордиенко Владислав Романович 	2001-01-01		админ	админ1
\.


--
-- Data for Name: objects; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.objects (object_id, object_status, square, room_count, object_address, construction_year, district, floor, price, property_type, owner_name, phone, registration_date) FROM stdin;
2	просмотрен	50	2	Комарова, 13	1990	СЖМ	8	5.9	квартира	Петров Петр Петрович	+7(999)888-7777	2023-10-10
3	просмотрен	81.7	3	Орбитальная ул., 90	2010	СЖМ	10	8.0	квартира	Николаев Николай Николаевич	+7(777)888-9966	2023-09-11
4	просмотрен	48	2	Московская ул., 13	1955	Центр	4	3.5	квартира	Яковлев Яков Яковлевич	+7(888)888-8888	2022-05-15
5	просмотрен	97	4	Башкирская ул., 4В	1985	СЖМ	5	9.99	квартира	Максимов Максим Максимович	+7(789)888-9988	2024-09-24
6	просмотрен	65.8	3	ул. Васильченко, 14	1969	Центр	4	6.65	квартира	Павлов Павел Павлович	+7(889)777-8899	2023-03-25
1	новый	61,2	3	ул.М.Горького, 20	2015	СЖМ	1	10.0	частный дом	Гордиенко Владислав Романович	+7(999)999-9999	2024-11-30
\.


--
-- Data for Name: purchase_orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.purchase_orders (purchase_order_id, square, room_cnt, year, district, floor, price, type, client_id, order_date) FROM stdin;
1	90	3	1970	Центр	3	6	квартира	1	2024-04-21
2	50	2	1980	Центр	3	6	квартира	2	2024-09-29
3	30	1	1970	Чкаловский	3	6	квартира	3	2024-06-29
\.


--
-- Data for Name: sale_applications; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sale_applications (sale_application_id, object_id, client_id) FROM stdin;
\.


--
-- Name: clients_client_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.clients_client_id_seq', 3, true);


--
-- Name: employees_employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employees_employee_id_seq', 2, true);


--
-- Name: objects_object_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.objects_object_id_seq', 6, true);


--
-- Name: purchase_orders_purchase_order_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.purchase_orders_purchase_order_id_seq', 3, true);


--
-- Name: sale_applications_sale_application_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sale_applications_sale_application_id_seq', 1, false);


--
-- Name: clients clients_client_phone_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clients
    ADD CONSTRAINT clients_client_phone_key UNIQUE (client_phone);


--
-- Name: clients clients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clients
    ADD CONSTRAINT clients_pkey PRIMARY KEY (client_id);


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
-- Name: objects objects_phone_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.objects
    ADD CONSTRAINT objects_phone_key UNIQUE (phone);


--
-- Name: objects objects_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.objects
    ADD CONSTRAINT objects_pkey PRIMARY KEY (object_id);


--
-- Name: purchase_orders purchase_orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchase_orders
    ADD CONSTRAINT purchase_orders_pkey PRIMARY KEY (purchase_order_id);


--
-- Name: sale_applications sale_applications_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sale_applications
    ADD CONSTRAINT sale_applications_pkey PRIMARY KEY (sale_application_id);


--
-- Name: purchase_orders purchase_orders_client_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchase_orders
    ADD CONSTRAINT purchase_orders_client_id_fkey FOREIGN KEY (client_id) REFERENCES public.clients(client_id) ON UPDATE CASCADE;


--
-- Name: sale_applications sale_applications_client_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sale_applications
    ADD CONSTRAINT sale_applications_client_id_fkey FOREIGN KEY (client_id) REFERENCES public.clients(client_id);


--
-- Name: sale_applications sale_applications_object_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sale_applications
    ADD CONSTRAINT sale_applications_object_id_fkey FOREIGN KEY (object_id) REFERENCES public.objects(object_id);


--
-- PostgreSQL database dump complete
--

