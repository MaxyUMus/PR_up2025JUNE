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
-- Name: reservations; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.reservations (
    reservation_id integer NOT NULL,
    visitor_id integer,
    service_id integer,
    datetime timestamp without time zone NOT NULL,
    worker_id integer,
    status character varying(50) NOT NULL,
    amount numeric(10,2)
);


ALTER TABLE public.reservations OWNER TO postgres;

--
-- Name: reservations_reservation_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.reservations_reservation_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.reservations_reservation_id_seq OWNER TO postgres;

--
-- Name: reservations_reservation_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.reservations_reservation_id_seq OWNED BY public.reservations.reservation_id;


--
-- Name: services; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.services (
    service_id integer NOT NULL,
    service_type character varying(100) NOT NULL,
    service_name character varying(255) NOT NULL,
    service_price numeric(10,2) NOT NULL
);


ALTER TABLE public.services OWNER TO postgres;

--
-- Name: services_service_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.services_service_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.services_service_id_seq OWNER TO postgres;

--
-- Name: services_service_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.services_service_id_seq OWNED BY public.services.service_id;


--
-- Name: visitors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.visitors (
    visitor_id integer NOT NULL,
    visitor_name character varying(255) NOT NULL,
    birth_date timestamp without time zone,
    phone character varying(50) NOT NULL,
    email character varying(255),
    bonus_points integer DEFAULT 0
);


ALTER TABLE public.visitors OWNER TO postgres;

--
-- Name: visitors_visitor_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.visitors_visitor_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.visitors_visitor_id_seq OWNER TO postgres;

--
-- Name: visitors_visitor_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.visitors_visitor_id_seq OWNED BY public.visitors.visitor_id;


--
-- Name: workers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.workers (
    worker_id integer NOT NULL,
    worker_name character varying(255) NOT NULL,
    worker_birth_date timestamp without time zone,
    worker_specialization character varying(100) NOT NULL,
    worker_description text,
    worker_phone character varying(50) NOT NULL,
    worker_login character varying(50),
    worker_password character varying(50)
);


ALTER TABLE public.workers OWNER TO postgres;

--
-- Name: workers_worker_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.workers_worker_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.workers_worker_id_seq OWNER TO postgres;

--
-- Name: workers_worker_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.workers_worker_id_seq OWNED BY public.workers.worker_id;


--
-- Name: reservations reservation_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservations ALTER COLUMN reservation_id SET DEFAULT nextval('public.reservations_reservation_id_seq'::regclass);


--
-- Name: services service_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.services ALTER COLUMN service_id SET DEFAULT nextval('public.services_service_id_seq'::regclass);


--
-- Name: visitors visitor_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.visitors ALTER COLUMN visitor_id SET DEFAULT nextval('public.visitors_visitor_id_seq'::regclass);


--
-- Name: workers worker_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.workers ALTER COLUMN worker_id SET DEFAULT nextval('public.workers_worker_id_seq'::regclass);


--
-- Data for Name: reservations; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.reservations (reservation_id, visitor_id, service_id, datetime, worker_id, status, amount) FROM stdin;
2	2	19	2024-10-10 09:00:00	6	выполнен	500.00
1	4	13	2024-11-05 12:25:00	3	выполнен	1850.00
3	1	7	2025-11-10 12:30:00	6	выполнен	50.00
4	2	1	2024-11-29 17:25:00	3	новый	\N
5	6	13	2024-11-22 12:30:00	2	выполнен	380.00
6	7	13	2024-11-22 12:30:00	3	новый	400.00
\.


--
-- Data for Name: services; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.services (service_id, service_type, service_name, service_price) FROM stdin;
1	Парикмахерские услуги	Стрижка женская короткие волосы	600.00
2	Парикмахерские услуги	Стрижка женская средние волосы	700.00
3	Парикмахерские услуги	Стрижка женская длинные волосы	800.00
4	Парикмахерские услуги	Стрижка челки	200.00
5	Парикмахерские услуги	Выпрямление челки	100.00
6	Парикмахерские услуги	Стрижка «по кончикам»	400.00
7	Парикмахерские услуги	Мытьё волос короткие	100.00
8	Парикмахерские услуги	Мытьё волос средние	150.00
9	Парикмахерские услуги	Мытьё волос длинные	200.00
10	Парикмахерские услуги	Сушка волос короткие	300.00
11	Парикмахерские услуги	Сушка волос средние	400.00
12	Парикмахерские услуги	Сушка волос длинные	500.00
13	Парикмахерские услуги	Укладка короткие	600.00
14	Парикмахерские услуги	Укладка средние	700.00
15	Парикмахерские услуги	Укладка длинные	800.00
16	Парикмахерские услуги	Стрижка мужская Под "ноль"	200.00
17	Парикмахерские услуги	Стрижка мужская "Спортивная"	400.00
18	Парикмахерские услуги	Стрижка мужская "Классическая"	500.00
19	Парикмахерские услуги	Стрижка мужская "Модельная"	500.00
20	Парикмахерские услуги	Стрижка мужская "Креативная"	600.00
21	Парикмахерские услуги	Оформление бороды	200.00
22	Парикмахерские услуги	Оформление усов	100.00
23	Маникюр и педикюр	Гигиенический маникюр	600.00
24	Маникюр и педикюр	Маникюр с укреплением и  гель-лаком	1700.00
25	Маникюр и педикюр	Укорачивание длины ногтей натур.	50.00
26	Маникюр и педикюр	Укорачивание длины ногтей искуств.	150.00
27	Косметология	Чистка лица ультразвуковая	2000.00
28	Косметология	Чистка лица комбинированная	1500.00
29	Косметология	Чистка лица гигиеническая	2000.00
30	Косметология	Демакияж	100.00
\.


--
-- Data for Name: visitors; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.visitors (visitor_id, visitor_name, birth_date, phone, email, bonus_points) FROM stdin;
4	Свистунов Соловей Карпович	1998-04-01 00:00:00	+7(777)888-88-88	mrsvist@yandex.ru	0
5	Князева Любава Путятишна	2002-08-19 00:00:00	+7(777)999-99-99	ogon@yandex.ru	0
7	Муромец Илья Иванович	2004-11-30 00:00:00	+7(999)666-66-66	primeta@yandex.ru	0
8	Богатырев Добрыня Никитич	1997-06-24 00:00:00	+7(666)999-99-99	upalotjalsya@yandex.ru	0
9	Прекрасная Василиса Федоровна	1999-12-28 00:00:00	+7(888)555-55-55	krasa@yandex.ru	0
3	Премудрая Василиса Егоровна	1995-10-25 00:00:00	+7(888)777-77-77	lisa@yandex.ru	18
6	Болотная Кикимора Аристарховна	2000-02-04 00:00:00	+7(888)666-66-66	kulic@yandex.ru	0
1	Бессмертный Кощей Спиридонович	1999-12-12 00:00:00	+7(999)888-88-88	kosha@yandex.ru	10
2	Царевич Иван Иванович	2000-03-09 00:00:00	+7(888)999-99-99	vanya@yandex.ru	0
\.


--
-- Data for Name: workers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.workers (worker_id, worker_name, worker_birth_date, worker_specialization, worker_description, worker_phone, worker_login, worker_password) FROM stdin;
2	Борменталь Иван Арнольдович	2002-01-25 00:00:00	Парикмахерские услуги	Парикмахер-универсал	+7(999)222-22-22	222	ббб
3	Иванова Дарья Петровна	1995-06-19 00:00:00	Маникюр и педикюр	Призер Всероссийского чемпионата мастеров маникюра	+7(999)323-22-33	333	ввв
4	Бунина Зинаида Прокофьевна	1999-11-11 00:00:00	Маникюр и педикюр		+7(999)424-22-44	444	ггг
5	Чурилова Лидия Алексеевна	1990-08-30 00:00:00	Косметология		+7(999)525-22-55	555	ддд
6	Преображенский Филипп Филиппович	1994-10-07 00:00:00	Парикмахерские услуги	Специалист по мужским стрижкам. Международный диплом	+7(999)626-22-66	666	еее
7	Чугункин Клим Иванович	1991-04-20 00:00:00	Парикмахерские услуги	Парикмахер-универсал	+7(999)727-22-77	777	жжж
1	Шариков Полиграф Полиграфович	2000-05-03 00:00:00	Парикмахерские услуги	Парикмахер 5 разряда. Стилист прически и макияжа. Международный диплом	+7(999)121-22-11	none	none
\.


--
-- Name: reservations_reservation_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.reservations_reservation_id_seq', 6, true);


--
-- Name: services_service_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.services_service_id_seq', 30, true);


--
-- Name: visitors_visitor_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.visitors_visitor_id_seq', 9, true);


--
-- Name: workers_worker_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.workers_worker_id_seq', 7, true);


--
-- Name: visitors chbonus_points_range; Type: CHECK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE public.visitors
    ADD CONSTRAINT chbonus_points_range CHECK (((bonus_points >= 1) AND (bonus_points <= 100))) NOT VALID;


--
-- Name: reservations reservations_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservations
    ADD CONSTRAINT reservations_pkey PRIMARY KEY (reservation_id);


--
-- Name: services services_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.services
    ADD CONSTRAINT services_pkey PRIMARY KEY (service_id);


--
-- Name: visitors visitors_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.visitors
    ADD CONSTRAINT visitors_pkey PRIMARY KEY (visitor_id);


--
-- Name: workers workers_login_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.workers
    ADD CONSTRAINT workers_login_key UNIQUE (worker_login);


--
-- Name: workers workers_phone_unique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.workers
    ADD CONSTRAINT workers_phone_unique UNIQUE (worker_phone);


--
-- Name: workers workers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.workers
    ADD CONSTRAINT workers_pkey PRIMARY KEY (worker_id);


--
-- Name: idx_reservations_service; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_reservations_service ON public.reservations USING btree (service_id);


--
-- Name: idx_reservations_visitor; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_reservations_visitor ON public.reservations USING btree (visitor_id);


--
-- Name: idx_reservations_worker; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_reservations_worker ON public.reservations USING btree (worker_id);


--
-- Name: reservations reservations_service_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservations
    ADD CONSTRAINT reservations_service_id_fkey FOREIGN KEY (service_id) REFERENCES public.services(service_id) ON DELETE SET NULL;


--
-- Name: reservations reservations_visitor_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservations
    ADD CONSTRAINT reservations_visitor_id_fkey FOREIGN KEY (visitor_id) REFERENCES public.visitors(visitor_id) ON DELETE CASCADE;


--
-- Name: reservations reservations_worker_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservations
    ADD CONSTRAINT reservations_worker_id_fkey FOREIGN KEY (worker_id) REFERENCES public.workers(worker_id) ON DELETE SET NULL;


--
-- PostgreSQL database dump complete
--

