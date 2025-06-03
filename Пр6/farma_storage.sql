--
-- PostgreSQL database dump
--

-- Dumped from database version 17.4
-- Dumped by pg_dump version 17.4

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
-- Name: partners; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.partners (
    partner_id integer NOT NULL,
    partner_type character varying(50) NOT NULL,
    partner_name character varying(255) NOT NULL,
    director character varying(255) NOT NULL,
    contact_person character varying(255) NOT NULL,
    email character varying(255) NOT NULL,
    phone character varying(50) NOT NULL,
    legal_address text NOT NULL,
    rating integer,
    CONSTRAINT partners_rating_check CHECK (((rating >= 1) AND (rating <= 10)))
);


ALTER TABLE public.partners OWNER TO postgres;

--
-- Name: partners_partner_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.partners_partner_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.partners_partner_id_seq OWNER TO postgres;

--
-- Name: partners_partner_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.partners_partner_id_seq OWNED BY public.partners.partner_id;


--
-- Name: products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.products (
    product_id integer NOT NULL,
    product_type character varying(100) NOT NULL,
    product_name character varying(255) NOT NULL,
    manufacturer character varying(255) NOT NULL,
    category character varying(255) NOT NULL,
    release_form text NOT NULL,
    expiry_date character varying(10),
    price numeric(10,2) NOT NULL,
    package character varying(50),
    stock_quantity integer NOT NULL
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
-- Name: sales; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sales (
    sale_id integer NOT NULL,
    partner_id integer NOT NULL,
    product_id integer NOT NULL,
    total_amount numeric(10,2) NOT NULL,
    sale_date timestamp without time zone NOT NULL,
    quantity integer NOT NULL,
    CONSTRAINT sales_quantity_check CHECK ((quantity > 0))
);


ALTER TABLE public.sales OWNER TO postgres;

--
-- Name: sales_sale_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sales_sale_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sales_sale_id_seq OWNER TO postgres;

--
-- Name: sales_sale_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sales_sale_id_seq OWNED BY public.sales.sale_id;


--
-- Name: suppliers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.suppliers (
    supplier_id integer NOT NULL,
    supplier_type character varying(50) NOT NULL,
    supplier_name character varying(255) NOT NULL,
    supply_history character varying
);


ALTER TABLE public.suppliers OWNER TO postgres;

--
-- Name: suppliers_supplier_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.suppliers_supplier_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.suppliers_supplier_id_seq OWNER TO postgres;

--
-- Name: suppliers_supplier_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.suppliers_supplier_id_seq OWNED BY public.suppliers.supplier_id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    users_id integer NOT NULL,
    users_name character varying(255) NOT NULL,
    birth_date date NOT NULL,
    passport_data character varying(20) NOT NULL,
    education character varying,
    phone character varying(16) NOT NULL,
    address character varying NOT NULL,
    login character varying(255) NOT NULL,
    password character varying(255) NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_users_id_seq OWNER TO postgres;

--
-- Name: users_users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_users_id_seq OWNED BY public.users.users_id;


--
-- Name: partners partner_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partners ALTER COLUMN partner_id SET DEFAULT nextval('public.partners_partner_id_seq'::regclass);


--
-- Name: products product_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products ALTER COLUMN product_id SET DEFAULT nextval('public.products_product_id_seq'::regclass);


--
-- Name: sales sale_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sales ALTER COLUMN sale_id SET DEFAULT nextval('public.sales_sale_id_seq'::regclass);


--
-- Name: suppliers supplier_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.suppliers ALTER COLUMN supplier_id SET DEFAULT nextval('public.suppliers_supplier_id_seq'::regclass);


--
-- Name: users users_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN users_id SET DEFAULT nextval('public.users_users_id_seq'::regclass);


--
-- Data for Name: partners; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.partners (partner_id, partner_type, partner_name, director, contact_person, email, phone, legal_address, rating) FROM stdin;
1	ООО	Семейная аптека «Апрель»	Иванова Александра Ивановна	Иванова Александра Ивановна	aleksandraivanova@ml.ru	493 123 45 67	652050, Кемеровская область, город Юрга, ул. Лесная, 15	7
2	ООО	Ригла	Петров Василий Петрович	Сидоркин Иван Михайлович	vppetrov@vl.ru	987 123 56 78	164500, Архангельская область, город Северодвинск, ул. Строителей, 18	8
3	ОАО	Наша аптека	Воробьева Екатерина Валерьевна	Воробьева Екатерина Валерьевна	ekaterina.vorobeva@ml.ru	444 222 33 11	143960, Московская область, город Реутов, ул. Свободы, 51	5
4	ЗАО	Аптека плюс	Степанов Степан Сергеевич	Степанов Степан Сергеевич	stepanov@stepan.ru	912 888 33 33	309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122	10
\.


--
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.products (product_id, product_type, product_name, manufacturer, category, release_form, expiry_date, price, package, stock_quantity) FROM stdin;
1	Лекарственные средства	Арбидол Максимум	Отисифарм Про АО, Россия	Противовирусное средство	капсулы 200 мг 20 шт	10.2026	950.00	40	38
2	Лекарственные средства	Арбидол Максимум	Отисифарм Про АО, Россия	Противовирусное средство	капсулы 200 мг 10 шт	09.2026	500.00	45	38
3	Витамины и бады	Турбослим Экспресс	Эвалар, Россия	Похудение	капсулы 200 мг 18 шт	09.2026	1000.00	30	50
4	Витамины и бады	Омега-3 из дикого камчатского лосося	Тымлатский Рыбокомбинат, Россия	БАД	капсулы 1000 мг, 160 шт.	06.2025	1550.00	25	10
5	Медицинские изделия	Вольтарен пластырь трансдермальный	Доджин Ияку-Како, Япония	пластырь	пластырь 15 мг 5 шт.	02.2026	520.00	60	20
6	Лекарственные средства	Випросал В	Гриндекс, Эстония	Заболевания опорно-двигательного аппарата	мазь 30 г	10.2026	490.00	55	24
\.


--
-- Data for Name: sales; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sales (sale_id, partner_id, product_id, total_amount, sale_date, quantity) FROM stdin;
1	1	1	114000.00	2023-03-23 00:00:00	3
2	1	2	77500.00	2023-12-18 00:00:00	2
3	1	3	26950.00	2024-06-07 00:00:00	1
4	2	1	114000.00	2022-12-02 00:00:00	3
5	2	4	22500.00	2023-05-17 00:00:00	1
6	2	5	30000.00	2024-06-07 00:00:00	1
7	2	6	31200.00	2024-07-01 00:00:00	1
8	3	1	38000.00	2023-01-22 00:00:00	1
9	3	4	22500.00	2024-07-05 00:00:00	1
10	4	4	22500.00	2023-09-19 00:00:00	1
11	4	5	77500.00	2023-11-10 00:00:00	2
12	4	4	45000.00	2024-04-15 00:00:00	2
\.


--
-- Data for Name: suppliers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.suppliers (supplier_id, supplier_type, supplier_name, supply_history) FROM stdin;
1	Производитель	Отисифарм Про АО, Россия	Поставки лекарственных средств
2	Производитель	Эвалар, Россия	Поставки витаминов и БАДов
3	Производитель	Тымлатский Рыбокомбинат, Россия	Поставки БАДов
4	Производитель	Доджин Ияку-Како, Япония	Поставки медицинских изделий
5	Производитель	Гриндекс, Эстония	Поставки лекарственных средств
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (users_id, users_name, birth_date, passport_data, education, phone, address, login, password) FROM stdin;
1	Иванов Иван Иванович	1990-05-15	1234 567890	Высшее	+7(999)123-45-67	г. Москва, ул. Пушкина, 10	none	none
2	Петрова Мария Сергеевна	1985-08-20	0987 654321	Среднее специальное	+7(999)765-43-21	г. Санкт-Петербург, ул. Лермонтова, 5	none2	none2
\.


--
-- Name: partners_partner_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.partners_partner_id_seq', 4, true);


--
-- Name: products_product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.products_product_id_seq', 6, true);


--
-- Name: sales_sale_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sales_sale_id_seq', 12, true);


--
-- Name: suppliers_supplier_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.suppliers_supplier_id_seq', 5, true);


--
-- Name: users_users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_users_id_seq', 2, true);


--
-- Name: partners partners_partner_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partners
    ADD CONSTRAINT partners_partner_name_key UNIQUE (partner_name);


--
-- Name: partners partners_phone_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partners
    ADD CONSTRAINT partners_phone_key UNIQUE (phone);


--
-- Name: partners partners_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partners
    ADD CONSTRAINT partners_pkey PRIMARY KEY (partner_id);


--
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (product_id);


--
-- Name: sales sales_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sales
    ADD CONSTRAINT sales_pkey PRIMARY KEY (sale_id);


--
-- Name: suppliers suppliers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.suppliers
    ADD CONSTRAINT suppliers_pkey PRIMARY KEY (supplier_id);


--
-- Name: suppliers suppliers_supplier_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.suppliers
    ADD CONSTRAINT suppliers_supplier_name_key UNIQUE (supplier_name);


--
-- Name: users users_login_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_login_key UNIQUE (login);


--
-- Name: users users_passport_data_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_passport_data_key UNIQUE (passport_data);


--
-- Name: users users_phone_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_phone_key UNIQUE (phone);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (users_id);


--
-- Name: users users_users_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_users_name_key UNIQUE (users_name);


--
-- Name: sales sales_partner_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sales
    ADD CONSTRAINT sales_partner_id_fkey FOREIGN KEY (partner_id) REFERENCES public.partners(partner_id) ON DELETE CASCADE;


--
-- Name: sales sales_product_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sales
    ADD CONSTRAINT sales_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.products(product_id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

