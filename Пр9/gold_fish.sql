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
-- Name: get_fish_price(numeric, character varying, date); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_fish_price(_count numeric, _name character varying, _d date) RETURNS numeric
    LANGUAGE plpgsql
    AS $$ 
begin 
    return case (extract(month from _d)) 
        when 9 then (select september_price * _count from tarifs where fish_name = _name)  
        when 10 then (select october_price * _count from tarifs where fish_name = _name)  
        else (select 160.00 * _count from tarifs where fish_name = _name) 
    end; 
end;
$$;


ALTER FUNCTION public.get_fish_price(_count numeric, _name character varying, _d date) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: clients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.clients (
    client_id integer NOT NULL,
    client_fullname character varying(150) NOT NULL,
    client_gender character(1),
    client_birth_date date,
    club_id integer,
    CONSTRAINT clients_client_gender_check CHECK ((client_gender = ANY (ARRAY['м'::bpchar, 'ж'::bpchar])))
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
-- Name: clubs; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.clubs (
    club_id integer NOT NULL,
    club_name character varying(50)
);


ALTER TABLE public.clubs OWNER TO postgres;

--
-- Name: clubs_club_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.clubs_club_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.clubs_club_id_seq OWNER TO postgres;

--
-- Name: clubs_club_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.clubs_club_id_seq OWNED BY public.clubs.club_id;


--
-- Name: employees; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employees (
    employee_id integer NOT NULL,
    employee_fullname character varying(150),
    employee_post character varying(50),
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
-- Name: tarifs; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tarifs (
    tarif_id integer NOT NULL,
    fish_name character varying(50),
    september_price numeric(10,2),
    october_price numeric(10,2)
);


ALTER TABLE public.tarifs OWNER TO postgres;

--
-- Name: tarifs_tarif_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tarifs_tarif_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.tarifs_tarif_id_seq OWNER TO postgres;

--
-- Name: tarifs_tarif_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tarifs_tarif_id_seq OWNED BY public.tarifs.tarif_id;


--
-- Name: visits; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.visits (
    visit_id integer NOT NULL,
    client_id integer,
    visit_number integer,
    house_number integer,
    move_date date NOT NULL,
    days_num integer,
    trout numeric(10,1),
    silver_carp numeric(10,1),
    carp numeric(10,1),
    crucian_carp numeric(10,1)
);


ALTER TABLE public.visits OWNER TO postgres;

--
-- Name: visits_visit_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.visits_visit_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.visits_visit_id_seq OWNER TO postgres;

--
-- Name: visits_visit_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.visits_visit_id_seq OWNED BY public.visits.visit_id;


--
-- Name: clients client_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clients ALTER COLUMN client_id SET DEFAULT nextval('public.clients_client_id_seq'::regclass);


--
-- Name: clubs club_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clubs ALTER COLUMN club_id SET DEFAULT nextval('public.clubs_club_id_seq'::regclass);


--
-- Name: employees employee_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees ALTER COLUMN employee_id SET DEFAULT nextval('public.employees_employee_id_seq'::regclass);


--
-- Name: tarifs tarif_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tarifs ALTER COLUMN tarif_id SET DEFAULT nextval('public.tarifs_tarif_id_seq'::regclass);


--
-- Name: visits visit_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.visits ALTER COLUMN visit_id SET DEFAULT nextval('public.visits_visit_id_seq'::regclass);


--
-- Data for Name: clients; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.clients (client_id, client_fullname, client_gender, client_birth_date, club_id) FROM stdin;
1	Михалов Игнат Васильевич	м	1985-12-12	1
2	Мороз Петр Петрович	м	1966-05-01	2
3	Солнцев Иван Сергеевич	м	1977-04-29	2
4	Васильев Андрей Михайлович	м	1959-10-04	2
5	Букин Михаил Сергеевич	м	1989-02-18	3
6	Лимонов Владимир Александрович	м	2000-06-30	2
7	Плетнев Аркадий Борисович	м	1968-07-01	2
8	Вакушина Светлана Ивановна	ж	1973-08-14	2
9	Ятькин Сергей Иванович	м	2001-04-19	3
10	Марьина Алевтина Матвеевна	ж	1955-01-06	1
11	Соколов Александр Иванович	м	1992-03-12	2
12	Пронин Василий Сергеевич	м	1988-02-27	2
13	Кукушкин Николай Олегович	м	1979-08-31	2
14	Назаров Валерий Петрович	м	1963-11-09	3
15	Трифонов Геннадий Николаевич	м	1989-05-18	2
16	Ястреб Герман Дмитриевич	м	1999-10-10	2
17	Востриков Вадим Алексеевич	м	1977-01-18	2
18	Гудков Семен Степанович	м	1985-04-20	3
19	Крендель Максим Борисович	м	1986-09-01	3
20	Мамаев Сидор Кирович	м	1951-07-15	1
\.


--
-- Data for Name: clubs; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.clubs (club_id, club_name) FROM stdin;
1	Блесна
2	На крючке
3	Пионер
\.


--
-- Data for Name: employees; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employees (employee_id, employee_fullname, employee_post, login, password) FROM stdin;
1	Пилипенко Максим Владимирович	Администратор	none	none
\.


--
-- Data for Name: tarifs; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tarifs (tarif_id, fish_name, september_price, october_price) FROM stdin;
1	Форель	200.00	220.00
2	Толстолобик	130.00	160.00
3	Карп	70.00	85.00
4	Карась	90.00	95.00
\.


--
-- Data for Name: visits; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.visits (visit_id, client_id, visit_number, house_number, move_date, days_num, trout, silver_carp, carp, crucian_carp) FROM stdin;
1	5	1	5	2024-09-12	1	0.0	1.2	3.2	1.7
2	8	2	2	2024-09-15	1	2.5	2.8	2.1	3.8
3	4	3	4	2024-10-05	2	4.0	0.0	2.4	1.3
4	4	4	4	2024-10-15	1	0.0	1.2	3.2	1.7
5	4	5	3	2024-10-18	2	0.4	1.5	3.0	2.6
6	17	6	5	2024-10-01	1	0.0	1.2	4.2	1.8
7	17	7	6	2024-10-25	2	1.7	3.1	0.0	3.1
8	18	8	6	2024-09-12	2	2.7	5.1	3.1	1.1
9	18	9	3	2024-10-05	2	1.7	3.1	4.1	3.7
10	19	10	4	2024-09-18	1	2.3	1.5	2.7	2.0
11	13	11	1	2024-10-01	2	2.7	5.1	3.1	1.5
12	13	12	2	2024-10-22	2	1.5	1.5	3.0	2.6
13	13	13	3	2024-10-23	1	0.0	1.2	3.2	1.2
14	6	14	5	2024-10-21	2	1.7	4.1	0.0	3.2
15	6	15	2	2024-09-11	2	2.7	5.1	3.1	1.1
16	20	16	4	2024-10-07	3	4.0	1.2	2.3	3.3
17	10	17	4	2024-09-10	1	3.9	2.7	1.9	3.1
18	10	18	5	2024-09-29	1	3.0	1.2	3.2	1.2
19	1	19	1	2024-09-12	2	2.5	2.7	4.5	1.5
20	1	20	6	2024-10-07	2	0.0	0.0	1.0	0.0
21	1	21	5	2024-10-15	2	2.7	5.1	3.1	1.1
22	2	22	2	2024-10-01	4	3.0	1.3	3.0	3.6
23	2	23	5	2024-10-19	2	0.0	1.5	3.0	2.6
24	2	24	1	2024-10-24	2	1.7	2.1	3.1	1.7
25	14	25	3	2024-09-11	2	2.7	5.1	3.1	1.1
26	14	26	4	2024-10-12	2	0.0	1.7	2.3	2.9
27	7	27	1	2024-09-10	2	0.0	1.5	3.0	3.6
28	7	28	1	2024-09-25	1	0.0	1.2	3.2	1.2
29	12	29	3	2024-10-12	2	1.7	3.1	0.0	1.1
30	11	30	5	2024-09-12	2	4.0	0.0	1.4	4.0
31	11	31	6	2024-09-25	1	0.0	3.2	3.7	1.2
32	11	32	2	2024-10-10	2	1.7	3.1	4.0	1.0
33	3	33	3	2024-09-11	1	2.9	0.0	2.9	2.9
34	3	34	1	2024-10-20	2	2.7	4.1	3.1	1.7
35	15	35	3	2024-09-12	2	2.7	5.1	3.7	1.1
36	15	36	3	2024-09-19	2	0.0	1.5	3.0	2.6
37	15	37	1	2024-10-28	1	2.3	1.5	2.7	2.0
38	16	38	4	2024-09-12	1	3.0	1.2	3.0	2.0
39	16	39	1	2024-09-18	1	0.0	1.2	3.2	1.2
40	9	40	3	2024-09-12	2	1.7	3.1	3.1	1.1
41	9	41	1	2024-10-11	2	2.5	2.8	2.1	3.8
\.


--
-- Name: clients_client_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.clients_client_id_seq', 20, true);


--
-- Name: clubs_club_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.clubs_club_id_seq', 3, true);


--
-- Name: employees_employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employees_employee_id_seq', 1, true);


--
-- Name: tarifs_tarif_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tarifs_tarif_id_seq', 4, true);


--
-- Name: visits_visit_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.visits_visit_id_seq', 41, true);


--
-- Name: clients clients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clients
    ADD CONSTRAINT clients_pkey PRIMARY KEY (client_id);


--
-- Name: clubs clubs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clubs
    ADD CONSTRAINT clubs_pkey PRIMARY KEY (club_id);


--
-- Name: employees employees_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees
    ADD CONSTRAINT employees_pkey PRIMARY KEY (employee_id);


--
-- Name: tarifs tarifs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tarifs
    ADD CONSTRAINT tarifs_pkey PRIMARY KEY (tarif_id);


--
-- Name: visits visits_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.visits
    ADD CONSTRAINT visits_pkey PRIMARY KEY (visit_id);


--
-- Name: clients clients_club_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clients
    ADD CONSTRAINT clients_club_id_fkey FOREIGN KEY (club_id) REFERENCES public.clubs(club_id);


--
-- Name: visits visits_client_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.visits
    ADD CONSTRAINT visits_client_id_fkey FOREIGN KEY (client_id) REFERENCES public.clients(client_id);


--
-- PostgreSQL database dump complete
--

