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
-- Name: buyers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.buyers (
    buyer_id integer NOT NULL,
    buyer_fullname character varying(100),
    phone_number character varying(16) NOT NULL,
    buyer_address character varying(200),
    CONSTRAINT buyers_phone_number_check CHECK (((phone_number)::text ~ '^\+7\(\d{3}\)-\d{3}-\d{4}$'::text))
);


ALTER TABLE public.buyers OWNER TO postgres;

--
-- Name: buyers_buyer_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.buyers_buyer_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.buyers_buyer_id_seq OWNER TO postgres;

--
-- Name: buyers_buyer_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.buyers_buyer_id_seq OWNED BY public.buyers.buyer_id;


--
-- Name: employees; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employees (
    employee_id integer NOT NULL,
    employee_fullname character varying(100),
    employee_birth_date date,
    phone_number character varying(16) NOT NULL,
    login character varying(100),
    password character varying(100),
    CONSTRAINT employees_phone_number_check CHECK (((phone_number)::text ~ '^\+7\(\d{3}\)-\d{3}-\d{4}$'::text))
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
-- Name: products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.products (
    product_id integer NOT NULL,
    product_category character varying(50),
    product_article character varying(20),
    product_name character varying(100),
    product_country character varying(50),
    product_price integer,
    product_quantity integer
);


ALTER TABLE public.products OWNER TO postgres;

--
-- Name: products_product_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.products_product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.products_product_id_seq OWNER TO postgres;

--
-- Name: products_product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.products_product_id_seq OWNED BY public.products.product_id;


--
-- Name: purchases; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.purchases (
    purchase_id integer NOT NULL,
    purchase_check_number integer,
    product_id integer,
    purchase_amount integer,
    buyer_id integer,
    purchase_date date NOT NULL,
    purchase_summ integer,
    delivery_date date,
    delivery_performer character varying(100),
    purchase_status character varying(20) DEFAULT 'новый'::character varying,
    purchase_priority character varying(20) DEFAULT 'средний'::character varying
);


ALTER TABLE public.purchases OWNER TO postgres;

--
-- Name: purchases_purchase_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.purchases_purchase_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.purchases_purchase_id_seq OWNER TO postgres;

--
-- Name: purchases_purchase_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.purchases_purchase_id_seq OWNED BY public.purchases.purchase_id;


--
-- Name: buyers buyer_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.buyers ALTER COLUMN buyer_id SET DEFAULT nextval('public.buyers_buyer_id_seq'::regclass);


--
-- Name: employees employee_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees ALTER COLUMN employee_id SET DEFAULT nextval('public.employees_employee_id_seq'::regclass);


--
-- Name: products product_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products ALTER COLUMN product_id SET DEFAULT nextval('public.products_product_id_seq'::regclass);


--
-- Name: purchases purchase_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchases ALTER COLUMN purchase_id SET DEFAULT nextval('public.purchases_purchase_id_seq'::regclass);


--
-- Data for Name: buyers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.buyers (buyer_id, buyer_fullname, phone_number, buyer_address) FROM stdin;
1	Иванова Александра Ивановна	+7(493)-123-4567	652050, Кемеровская область, город \nЮрга, ул. Лесная, 15
2	Петров Василий Петрович	+7(987)-123-5678	164500, Архангельская область, город \nСеверодвинск, ул. Строителей, 18
3	Воробьева Екатерина Валерьевна	+7(444)-222-3311	143960, Московская область, город \nРеутов, ул. Свободы, 51
4	Степанов Степан Сергеевич	+7(912)-888-3333	309500, Белгородская область, город Старый \nОскол, ул. Рабочая, 122
\.


--
-- Data for Name: employees; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employees (employee_id, employee_fullname, employee_birth_date, phone_number, login, password) FROM stdin;
4	Пилипенко Максим Владимирович	2006-12-06	+7(951)-537-2747	none	none
\.


--
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.products (product_id, product_category, product_article, product_name, product_country, product_price, product_quantity) FROM stdin;
1	техника для кухни	450991	Холодильник CANDY CCRN 6180 W	Россия	39999	5
2	техника для кухни	599248	Холодильник HAIER C2F637CXRGU1	Россия	69999	3
3	техника для кухни	400339	Плита электрическая DARINA В 33404W	Россия	17299	10
4	техника для кухни	301629	Плита электрическая LERAN ECC 3607 W	Россия	29990	7
5	техника для кухни	460535	Микроволновая печь GORENJE MO20E1W	Россия	10299	10
6	теле-видео-аудио	531792	Телевизор DOFFLER 24KH29	Белоруссия	9990	5
7	теле-видео-аудио	569513	Smart телевизор PHILIPS 50PUS8108/60	Россия	45209	2
8	техника для дома	446075	Стиральная машина LERAN WMS 27106 WD2	Китай	24990	7
9	техника для дома	418012	Пылесос KITFORT КТ-535-1	Китай	14990	6
10	техника для дома	357658	Утюг LERAN CEI 700	Россия	5290	10
\.


--
-- Data for Name: purchases; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.purchases (purchase_id, purchase_check_number, product_id, purchase_amount, buyer_id, purchase_date, purchase_summ, delivery_date, delivery_performer, purchase_status, purchase_priority) FROM stdin;
1	2365894	3	1	1	2024-11-29	17799	2024-12-10	\N	новый	текущий
2	2365895	2	1	2	2024-11-29	67999	2024-12-05	\N	новый	срочный
3	2365896	6	1	3	2024-12-01	9790	2024-12-07	\N	новый	текущий
4	2365896	10	1	\N	2024-12-01	5290	\N	\N	\N	\N
5	2365897	5	1	\N	2024-12-01	10299	\N	\N	\N	\N
6	2365898	10	2	\N	2024-12-03	10580	\N	\N	\N	\N
\.


--
-- Name: buyers_buyer_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.buyers_buyer_id_seq', 4, true);


--
-- Name: employees_employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employees_employee_id_seq', 4, true);


--
-- Name: products_product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.products_product_id_seq', 10, true);


--
-- Name: purchases_purchase_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.purchases_purchase_id_seq', 6, true);


--
-- Name: buyers buyers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.buyers
    ADD CONSTRAINT buyers_pkey PRIMARY KEY (buyer_id);


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
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (product_id);


--
-- Name: purchases purchases_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchases
    ADD CONSTRAINT purchases_pkey PRIMARY KEY (purchase_id);


--
-- Name: purchases purchases_buyer_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchases
    ADD CONSTRAINT purchases_buyer_id_fkey FOREIGN KEY (buyer_id) REFERENCES public.buyers(buyer_id);


--
-- Name: purchases purchases_product_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchases
    ADD CONSTRAINT purchases_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.products(product_id);


--
-- PostgreSQL database dump complete
--

