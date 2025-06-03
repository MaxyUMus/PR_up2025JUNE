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
-- Name: employees; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employees (
    employee_id integer NOT NULL,
    employee_fullname character varying(200),
    employee_birthdate date,
    employee_number character varying(100),
    employee_login character varying(100),
    employee_password character varying(100)
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
    product_category character varying(100),
    product_name character varying(100),
    product_producer character varying(100),
    product_price numeric,
    product_package character varying(100),
    product_size character varying(100),
    produtc_unit character varying(100),
    product_creation_date date,
    product_expiration_date date,
    product_stock_amount integer
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
-- Name: sale_lists; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sale_lists (
    sale_list_id integer NOT NULL,
    sale_list_number integer,
    product_id integer,
    amount integer
);


ALTER TABLE public.sale_lists OWNER TO postgres;

--
-- Name: sale_lists_sale_list_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sale_lists_sale_list_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sale_lists_sale_list_id_seq OWNER TO postgres;

--
-- Name: sale_lists_sale_list_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sale_lists_sale_list_id_seq OWNED BY public.sale_lists.sale_list_id;


--
-- Name: sales; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sales (
    sale_id integer NOT NULL,
    sale_date date,
    sale_list_id integer,
    employee_id integer,
    amount integer,
    summ numeric
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
-- Name: supply_lists; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.supply_lists (
    supply_list_id integer NOT NULL,
    supply_list_number integer,
    product_id integer
);


ALTER TABLE public.supply_lists OWNER TO postgres;

--
-- Name: supply_lists_supply_list_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.supply_lists_supply_list_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.supply_lists_supply_list_id_seq OWNER TO postgres;

--
-- Name: supply_lists_supply_list_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.supply_lists_supply_list_id_seq OWNED BY public.supply_lists.supply_list_id;


--
-- Name: supplys; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.supplys (
    supply_id integer NOT NULL,
    supply_date timestamp without time zone,
    supply_list_id integer,
    supplier character varying(100)
);


ALTER TABLE public.supplys OWNER TO postgres;

--
-- Name: supplys_supply_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.supplys_supply_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.supplys_supply_id_seq OWNER TO postgres;

--
-- Name: supplys_supply_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.supplys_supply_id_seq OWNED BY public.supplys.supply_id;


--
-- Name: employees employee_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees ALTER COLUMN employee_id SET DEFAULT nextval('public.employees_employee_id_seq'::regclass);


--
-- Name: products product_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products ALTER COLUMN product_id SET DEFAULT nextval('public.products_product_id_seq'::regclass);


--
-- Name: sale_lists sale_list_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sale_lists ALTER COLUMN sale_list_id SET DEFAULT nextval('public.sale_lists_sale_list_id_seq'::regclass);


--
-- Name: sales sale_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sales ALTER COLUMN sale_id SET DEFAULT nextval('public.sales_sale_id_seq'::regclass);


--
-- Name: supply_lists supply_list_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supply_lists ALTER COLUMN supply_list_id SET DEFAULT nextval('public.supply_lists_supply_list_id_seq'::regclass);


--
-- Name: supplys supply_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supplys ALTER COLUMN supply_id SET DEFAULT nextval('public.supplys_supply_id_seq'::regclass);


--
-- Data for Name: employees; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employees (employee_id, employee_fullname, employee_birthdate, employee_number, employee_login, employee_password) FROM stdin;
1	Пилипенко Максим Владимирович	2006-12-06	+7(951)537-2747	none	none
\.


--
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.products (product_id, product_category, product_name, product_producer, product_price, product_package, product_size, produtc_unit, product_creation_date, product_expiration_date, product_stock_amount) FROM stdin;
1	Молоко и сливки	Молоко 1,5% ультрапастеризованное БЗМЖ	Простоквашино	149	Tetra Pak	970 мл	\N	2024-11-25	2024-12-03	20
2	Молоко и сливки	Молоко пастеризованное 2.5%	Простоквашино	90	Пластиковая бутылка	930 мл	\N	2024-11-28	2024-12-02	30
3	Молоко и сливки	Молоко питьевое пастеризованное 3.2%	Зелёная Линия	89.99	Пластиковая бутылка	900 мл	\N	2024-11-28	2024-12-03	15
4	Молоко и сливки	Молоко отборное 3.4-6%	Кубанский Молочник	159.99	Пластиковая бутылка	1.4л	\N	2024-11-24	2024-12-06	20
5	Кисломолочные продукты	Кефир 3,2% бзмж	Простоквашино	95	Пластиковая бутылка	930 мл	\N	2024-11-20	2024-12-02	10
7	Кисломолочные продукты	Кефир2,5% бзмж	Агрокомплекс	74	Пластиковый пакет	900 мл	\N	2024-11-25	2024-12-02	10
8	Сыры	Сыр Ламбер полутвердый 50%	Вимм Биль Данн	279	Вакуумная упаковка	230г	\N	2024-10-10	2024-12-10	18
9	Сыры	Сыр полутвердый Маасдам 45% бзмж	Брест-Литовск	200	Вакуумная упаковка	200 г	\N	2024-10-11	2024-12-12	15
10	Сыры	Сыр творожный с зеленью 60% бзмж	Almette	150	Картонный стакан	150 г	\N	2024-10-22	2024-12-10	10
6	Кисломолочные продукты	Кефир 2,5% бзмж	Молочная легенда	110	Пластиковая бутылка	900 мл	\N	2024-11-20	2024-12-02	10
\.


--
-- Data for Name: sale_lists; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sale_lists (sale_list_id, sale_list_number, product_id, amount) FROM stdin;
1	2365894	2	2
2	2365895	9	2
3	2365896	3	1
4	4	6	1
\.


--
-- Data for Name: sales; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sales (sale_id, sale_date, sale_list_id, employee_id, amount, summ) FROM stdin;
1	2024-11-29	1	\N	\N	724.98
2	2024-11-29	2	\N	\N	400
3	2024-11-29	3	\N	\N	368.99
4	2025-05-31	4	1	1	88.0
\.


--
-- Data for Name: supply_lists; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.supply_lists (supply_list_id, supply_list_number, product_id) FROM stdin;
\.


--
-- Data for Name: supplys; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.supplys (supply_id, supply_date, supply_list_id, supplier) FROM stdin;
\.


--
-- Name: employees_employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employees_employee_id_seq', 1, true);


--
-- Name: products_product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.products_product_id_seq', 10, true);


--
-- Name: sale_lists_sale_list_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sale_lists_sale_list_id_seq', 36, true);


--
-- Name: sales_sale_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sales_sale_id_seq', 36, true);


--
-- Name: supply_lists_supply_list_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.supply_lists_supply_list_id_seq', 1, false);


--
-- Name: supplys_supply_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.supplys_supply_id_seq', 1, false);


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
-- Name: sale_lists sale_lists_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sale_lists
    ADD CONSTRAINT sale_lists_pkey PRIMARY KEY (sale_list_id);


--
-- Name: sales sales_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sales
    ADD CONSTRAINT sales_pkey PRIMARY KEY (sale_id);


--
-- Name: supply_lists supply_lists_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supply_lists
    ADD CONSTRAINT supply_lists_pkey PRIMARY KEY (supply_list_id);


--
-- Name: supplys supplys_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supplys
    ADD CONSTRAINT supplys_pkey PRIMARY KEY (supply_id);


--
-- Name: sale_lists sale_lists_product_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sale_lists
    ADD CONSTRAINT sale_lists_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.products(product_id);


--
-- Name: sales sales_employee_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sales
    ADD CONSTRAINT sales_employee_id_fkey FOREIGN KEY (employee_id) REFERENCES public.employees(employee_id);


--
-- Name: sales sales_sale_list_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sales
    ADD CONSTRAINT sales_sale_list_id_fkey FOREIGN KEY (sale_list_id) REFERENCES public.sale_lists(sale_list_id);


--
-- Name: supply_lists supply_lists_product_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supply_lists
    ADD CONSTRAINT supply_lists_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.products(product_id);


--
-- Name: supplys supplys_supply_list_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supplys
    ADD CONSTRAINT supplys_supply_list_id_fkey FOREIGN KEY (supply_list_id) REFERENCES public.supply_lists(supply_list_id);


--
-- PostgreSQL database dump complete
--

