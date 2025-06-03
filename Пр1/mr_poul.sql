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
-- Name: material_types; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.material_types (
    material_type_id integer NOT NULL,
    material_type character varying(100) NOT NULL,
    defect_percentage numeric(5,4) NOT NULL
);


ALTER TABLE public.material_types OWNER TO postgres;

--
-- Name: material_types_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.material_types_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.material_types_type_id_seq OWNER TO postgres;

--
-- Name: material_types_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.material_types_type_id_seq OWNED BY public.material_types.material_type_id;


--
-- Name: materials; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.materials (
    material_id integer NOT NULL,
    material_type_id integer,
    material_name character varying(100) NOT NULL,
    supplier character varying(100),
    purchase_price numeric(10,2),
    stock_quantity integer
);


ALTER TABLE public.materials OWNER TO postgres;

--
-- Name: materials_material_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.materials_material_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.materials_material_id_seq OWNER TO postgres;

--
-- Name: materials_material_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.materials_material_id_seq OWNED BY public.materials.material_id;


--
-- Name: partner_products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.partner_products (
    sale_id integer NOT NULL,
    product_id integer NOT NULL,
    partner_id integer NOT NULL,
    quantity integer NOT NULL,
    sale_date timestamp without time zone NOT NULL,
    CONSTRAINT partner_products_quantity_check CHECK ((quantity > 0))
);


ALTER TABLE public.partner_products OWNER TO postgres;

--
-- Name: partner_products_sale_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.partner_products_sale_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.partner_products_sale_id_seq OWNER TO postgres;

--
-- Name: partner_products_sale_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.partner_products_sale_id_seq OWNED BY public.partner_products.sale_id;


--
-- Name: partners; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.partners (
    partner_id integer NOT NULL,
    partner_type character varying(100) NOT NULL,
    partner_name character varying(100) NOT NULL,
    director character varying(100) NOT NULL,
    email character varying(100) NOT NULL,
    phone character varying(100) NOT NULL,
    legal_address text NOT NULL,
    inn character varying(15) NOT NULL,
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
-- Name: product_materials; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product_materials (
    product_materials_id integer NOT NULL,
    product_id integer NOT NULL,
    material_id integer NOT NULL,
    quantity_required numeric(10,2) NOT NULL,
    CONSTRAINT product_materials_quantity_required_check CHECK ((quantity_required > (0)::numeric))
);


ALTER TABLE public.product_materials OWNER TO postgres;

--
-- Name: product_materials_product_materials_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.product_materials_product_materials_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.product_materials_product_materials_id_seq OWNER TO postgres;

--
-- Name: product_materials_product_materials_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.product_materials_product_materials_id_seq OWNED BY public.product_materials.product_materials_id;


--
-- Name: product_types; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product_types (
    product_type_id integer NOT NULL,
    product_type character varying(100) NOT NULL,
    coefficient numeric(4,2) NOT NULL
);


ALTER TABLE public.product_types OWNER TO postgres;

--
-- Name: product_types_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.product_types_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.product_types_type_id_seq OWNER TO postgres;

--
-- Name: product_types_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.product_types_type_id_seq OWNED BY public.product_types.product_type_id;


--
-- Name: products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.products (
    product_id integer NOT NULL,
    product_type_id integer NOT NULL,
    product_name character varying(100) NOT NULL,
    article character varying(100) NOT NULL,
    min_partner_price numeric(10,2) NOT NULL
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
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    users_id integer NOT NULL,
    login character varying,
    password character varying
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
-- Name: material_types material_type_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material_types ALTER COLUMN material_type_id SET DEFAULT nextval('public.material_types_type_id_seq'::regclass);


--
-- Name: materials material_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.materials ALTER COLUMN material_id SET DEFAULT nextval('public.materials_material_id_seq'::regclass);


--
-- Name: partner_products sale_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partner_products ALTER COLUMN sale_id SET DEFAULT nextval('public.partner_products_sale_id_seq'::regclass);


--
-- Name: partners partner_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partners ALTER COLUMN partner_id SET DEFAULT nextval('public.partners_partner_id_seq'::regclass);


--
-- Name: product_materials product_materials_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_materials ALTER COLUMN product_materials_id SET DEFAULT nextval('public.product_materials_product_materials_id_seq'::regclass);


--
-- Name: product_types product_type_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_types ALTER COLUMN product_type_id SET DEFAULT nextval('public.product_types_type_id_seq'::regclass);


--
-- Name: products product_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products ALTER COLUMN product_id SET DEFAULT nextval('public.products_product_id_seq'::regclass);


--
-- Name: users users_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN users_id SET DEFAULT nextval('public.users_users_id_seq'::regclass);


--
-- Data for Name: material_types; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.material_types (material_type_id, material_type, defect_percentage) FROM stdin;
1	Тип материала 1	0.0010
2	Тип материала 2	0.0095
3	Тип материала 3	0.0028
4	Тип материала 4	0.0055
5	Тип материала 5	0.0034
\.


--
-- Data for Name: materials; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.materials (material_id, material_type_id, material_name, supplier, purchase_price, stock_quantity) FROM stdin;
1	1	Материал 1А	Поставщик A	100.00	50
2	1	Материал 1Б	Поставщик B	150.00	30
3	2	Материал 2А	Поставщик C	200.00	20
4	2	Материал 2Б	Поставщик D	250.00	15
5	3	Материал 3А	Поставщик E	300.00	40
6	3	Материал 3Б	Поставщик F	350.00	25
7	4	Материал 4А	Поставщик G	400.00	10
8	4	Материал 4Б	Поставщик H	450.00	5
9	5	Материал 5А	Поставщик I	500.00	8
10	5	Материал 5Б	Поставщик J	550.00	12
\.


--
-- Data for Name: partner_products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.partner_products (sale_id, product_id, partner_id, quantity, sale_date) FROM stdin;
1	1	1	15500	2023-03-23 00:00:00
2	3	1	12350	2023-12-18 00:00:00
3	4	1	37400	2024-06-07 00:00:00
4	2	2	35000	2022-12-02 00:00:00
5	5	2	1250	2023-05-17 00:00:00
6	3	2	1000	2024-06-07 00:00:00
7	1	2	7550	2024-07-01 00:00:00
8	1	3	7250	2023-01-22 00:00:00
9	2	3	2500	2024-07-05 00:00:00
10	4	4	59050	2023-03-20 00:00:00
11	3	4	37200	2024-03-12 00:00:00
12	5	4	4500	2024-05-14 00:00:00
13	3	5	50000	2023-09-19 00:00:00
14	4	5	670000	2023-11-10 00:00:00
15	1	5	35000	2024-04-15 00:00:00
16	2	5	25000	2024-06-12 00:00:00
\.


--
-- Data for Name: partners; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.partners (partner_id, partner_type, partner_name, director, email, phone, legal_address, inn, rating) FROM stdin;
1	ЗАО	База Строитель	Иванова Александра Ивановна	aleksandraivanova@ml.ru	493 123 45 67	652050, Кемеровская область, город Юрга, ул. Лесная, 15	2222455179	7
2	ООО	Паркет 29	Петров Василий Петрович	vppetrov@vl.ru	987 123 56 78	164500, Архангельская область, город Северодвинск, ул. Строителей, 18	3333888520	7
3	ПАО	Стройсервис	Соловьев Андрей Николаевич	ansolovev@st.ru	812 223 32 00	188910, Ленинградская область, город Приморск, ул. Парковая, 21	4440391035	7
4	ОАО	Ремонт и отделка	Воробьева Екатерина Валерьевна	ekaterina.vorobeva@ml.ru	444 222 33 11	143960, Московская область, город Реутов, ул. Свободы, 51	1111520857	5
5	ЗАО	МонтажПро	Степанов Степан Сергеевич	stepanov@stepan.ru	912 888 33 33	309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122	5552431140	10
\.


--
-- Data for Name: product_materials; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.product_materials (product_materials_id, product_id, material_id, quantity_required) FROM stdin;
1	1	3	2.50
2	1	5	1.00
3	2	4	3.00
4	3	1	0.50
5	3	2	1.50
6	4	7	2.00
7	5	9	4.00
\.


--
-- Data for Name: product_types; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.product_types (product_type_id, product_type, coefficient) FROM stdin;
1	Ламинат	2.35
2	Паркетная доска	4.34
3	Пробковое покрытие	1.50
\.


--
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.products (product_id, product_type_id, product_name, article, min_partner_price) FROM stdin;
1	2	Паркетная доска Ясень темный однополосная 14 мм	8758385	4456.90
2	2	Инженерная доска Дуб Французская елка однополосная 12 мм	8858958	7330.99
3	1	Ламинат Дуб дымчато-белый 33 класс 12 мм	7750282	1799.33
4	1	Ламинат Дуб серый 32 класс 8 мм с фаской	7028748	3890.41
5	3	Пробковое напольное клеевое покрытие 32 класс 4 мм	5012543	5450.59
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (users_id, login, password) FROM stdin;
1	none	none
\.


--
-- Name: material_types_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.material_types_type_id_seq', 5, true);


--
-- Name: materials_material_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.materials_material_id_seq', 10, true);


--
-- Name: partner_products_sale_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.partner_products_sale_id_seq', 16, true);


--
-- Name: partners_partner_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.partners_partner_id_seq', 5, true);


--
-- Name: product_materials_product_materials_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.product_materials_product_materials_id_seq', 7, true);


--
-- Name: product_types_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.product_types_type_id_seq', 3, true);


--
-- Name: products_product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.products_product_id_seq', 5, true);


--
-- Name: users_users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_users_id_seq', 1, true);


--
-- Name: material_types material_types_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material_types
    ADD CONSTRAINT material_types_pkey PRIMARY KEY (material_type_id);


--
-- Name: materials materials_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.materials
    ADD CONSTRAINT materials_pkey PRIMARY KEY (material_id);


--
-- Name: partner_products partner_products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partner_products
    ADD CONSTRAINT partner_products_pkey PRIMARY KEY (sale_id);


--
-- Name: partners partners_inn_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partners
    ADD CONSTRAINT partners_inn_key UNIQUE (inn);


--
-- Name: partners partners_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partners
    ADD CONSTRAINT partners_pkey PRIMARY KEY (partner_id);


--
-- Name: product_materials product_materials_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_materials
    ADD CONSTRAINT product_materials_pkey PRIMARY KEY (product_materials_id);


--
-- Name: product_materials product_materials_product_id_material_id_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_materials
    ADD CONSTRAINT product_materials_product_id_material_id_key UNIQUE (product_id, material_id);


--
-- Name: product_types product_types_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_types
    ADD CONSTRAINT product_types_pkey PRIMARY KEY (product_type_id);


--
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (product_id);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (users_id);


--
-- Name: idx_partner_products_date; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_partner_products_date ON public.partner_products USING btree (sale_date);


--
-- Name: idx_partners_name; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_partners_name ON public.partners USING btree (partner_name);


--
-- Name: idx_product_materials_material; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_product_materials_material ON public.product_materials USING btree (material_id);


--
-- Name: idx_product_materials_product; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_product_materials_product ON public.product_materials USING btree (product_id);


--
-- Name: idx_products_name; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_products_name ON public.products USING btree (product_name);


--
-- Name: materials materials_material_type_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.materials
    ADD CONSTRAINT materials_material_type_id_fkey FOREIGN KEY (material_type_id) REFERENCES public.material_types(material_type_id);


--
-- Name: partner_products partner_products_partner_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partner_products
    ADD CONSTRAINT partner_products_partner_id_fkey FOREIGN KEY (partner_id) REFERENCES public.partners(partner_id);


--
-- Name: partner_products partner_products_product_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partner_products
    ADD CONSTRAINT partner_products_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.products(product_id);


--
-- Name: product_materials product_materials_material_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_materials
    ADD CONSTRAINT product_materials_material_id_fkey FOREIGN KEY (material_id) REFERENCES public.materials(material_id);


--
-- Name: product_materials product_materials_product_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_materials
    ADD CONSTRAINT product_materials_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.products(product_id);


--
-- Name: products products_product_type_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_product_type_id_fkey FOREIGN KEY (product_type_id) REFERENCES public.product_types(product_type_id);


--
-- PostgreSQL database dump complete
--

