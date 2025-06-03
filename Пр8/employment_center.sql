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
-- Name: aspirants; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.aspirants (
    aspirant_id integer NOT NULL,
    aspirant_fullname character varying(100) NOT NULL,
    aspirant_birth_date date,
    aspirant_gender character varying(1),
    aspirant_post character varying(100),
    aspirant_education character varying(100),
    aspirant_qualification character varying(50),
    aspirant_exp integer,
    aspirant_salary integer,
    aspirant_other_info text,
    aspirant_filling_date date
);


ALTER TABLE public.aspirants OWNER TO postgres;

--
-- Name: aspirants_aspirant_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.aspirants_aspirant_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.aspirants_aspirant_id_seq OWNER TO postgres;

--
-- Name: aspirants_aspirant_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.aspirants_aspirant_id_seq OWNED BY public.aspirants.aspirant_id;


--
-- Name: deals; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.deals (
    deal_id integer NOT NULL,
    aspirant_id integer,
    vacancy_id integer,
    employee_id integer,
    deal_date date,
    deal_status character varying(50)
);


ALTER TABLE public.deals OWNER TO postgres;

--
-- Name: deals_deal_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.deals_deal_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.deals_deal_id_seq OWNER TO postgres;

--
-- Name: deals_deal_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.deals_deal_id_seq OWNED BY public.deals.deal_id;


--
-- Name: employees; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employees (
    employee_id integer NOT NULL,
    employee_fullname character varying(100) NOT NULL,
    employee_post character varying(100),
    phone_number character varying(16) NOT NULL,
    login character varying(50),
    password character varying(50),
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
-- Name: vacancys; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.vacancys (
    vacancy_id integer NOT NULL,
    vacancy_organization character varying(100) NOT NULL,
    activity_type text,
    vacancy_address character varying(100),
    organization_features text,
    vacancy_name character varying(100),
    phone_number character varying(16) NOT NULL,
    gender character varying(1),
    post character varying(100),
    qualification character varying(50),
    rights character varying(10),
    pc_skills text,
    foreign_languages character varying(50),
    job_functions text,
    salary integer,
    work_confitions text,
    other_info text,
    filling_date date,
    quantity integer,
    CONSTRAINT vacancys_phone_number_check CHECK (((phone_number)::text ~ '^\+7\(\d{3}\)-\d{3}-\d{4}$'::text))
);


ALTER TABLE public.vacancys OWNER TO postgres;

--
-- Name: vacancys_vacancy_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.vacancys_vacancy_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.vacancys_vacancy_id_seq OWNER TO postgres;

--
-- Name: vacancys_vacancy_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.vacancys_vacancy_id_seq OWNED BY public.vacancys.vacancy_id;


--
-- Name: aspirants aspirant_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.aspirants ALTER COLUMN aspirant_id SET DEFAULT nextval('public.aspirants_aspirant_id_seq'::regclass);


--
-- Name: deals deal_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.deals ALTER COLUMN deal_id SET DEFAULT nextval('public.deals_deal_id_seq'::regclass);


--
-- Name: employees employee_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees ALTER COLUMN employee_id SET DEFAULT nextval('public.employees_employee_id_seq'::regclass);


--
-- Name: vacancys vacancy_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vacancys ALTER COLUMN vacancy_id SET DEFAULT nextval('public.vacancys_vacancy_id_seq'::regclass);


--
-- Data for Name: aspirants; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.aspirants (aspirant_id, aspirant_fullname, aspirant_birth_date, aspirant_gender, aspirant_post, aspirant_education, aspirant_qualification, aspirant_exp, aspirant_salary, aspirant_other_info, aspirant_filling_date) FROM stdin;
1	Шариков Полиграф Полиграфович	1990-05-03	м	электрик	среднее специальное	4 \nгруппа	15	30000	\N	2024-08-01
2	Борменталь Иван Арнольдович	1985-01-25	м	инженер-конструктор	высшее \nпрофессиональное техническое	I категория	18	80000	\N	2024-10-15
3	Иванова Дарья Петровна	1995-06-19	ж	бухгалтер	среднее специальное	-	10	50000	\N	2024-11-11
4	Бунина Зинаида Прокофьевна	1999-11-11	ж	делопроизводитель	среднее \nспециальное	-	5	50000	\N	2024-10-15
5	Чурилова Лидия Алексеевна	1990-08-30	ж	секретарь	среднее специальное	-	10	40000	\N	2024-09-22
6	Преображенский Филипп Филиппович	1994-10-07	м	инженер-конструктор	высшее \nпрофессиональное техническое	II категория	10	80000	\N	2024-07-03
7	Чугункин Клим Иванович	1991-04-20	м	водитель	среднее	-	15	50000	С, D	2024-10-27
\.


--
-- Data for Name: deals; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.deals (deal_id, aspirant_id, vacancy_id, employee_id, deal_date, deal_status) FROM stdin;
1	7	6	3	2024-12-26	отказ соискателя
2	6	7	3	2024-12-22	отказ работодателя
3	6	3	3	2025-02-20	отказ работодателя
\.


--
-- Data for Name: employees; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employees (employee_id, employee_fullname, employee_post, phone_number, login, password) FROM stdin;
1	Бессмертный Кощей Спиридонович	директор	+7(999)-888-8888	кощей	1
2	Царевич Иван Иванович	администратор	+7(888)-999-9999	adm	adm
3	Премудрая Василиса Егоровна	агент	+7(888)-777-7777	Премудрая	111
4	Пилипенко Максим Владимирович	владелец сети	+7(951)-537-2747	none	none
\.


--
-- Data for Name: vacancys; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.vacancys (vacancy_id, vacancy_organization, activity_type, vacancy_address, organization_features, vacancy_name, phone_number, gender, post, qualification, rights, pc_skills, foreign_languages, job_functions, salary, work_confitions, other_info, filling_date, quantity) FROM stdin;
1	ООО АвиаДон	авиационное оборудование и специальная аэродромная техника	г.Ростов-на-Дону	ненормированный рабочий день	Иванова Александра Ивановна	+7(999)-888-7766	-	инженер-конструктор	II категория	-	инженерное ПО	английский	чертежные работы	80000	ненормированный рабочий день	стаж не менее 1 года, высшее \nобразование по специальности	2025-01-22	2
2	ООО АвиаДон	авиационное оборудование и специальная аэродромная техника	г.Ростов-на-Дону	ненормированный рабочий день	Иванова Александра Ивановна	+7(999)-888-7766	м	водитель	-	D	-	-	-	50000	ненормированный рабочий день	стаж не \nменее 1 года	2025-01-22	2
3	Турбулентность-Дон, Группа компаний	разработка и производство приборов учета газа, \nводы, тепла для технического и коммерческого учета	г.Ростов-на-Дону	ненормированный \nрабочий день	Степанов Степан Сергеевич	+7(999)-777-6655	-	инженер-конструктор	I \nкатегория	-	инженерное ПО	английский	чертежные работы	120000	ненормированный \nрабочий день	стаж не менее 5 лет, высшее образование по специальности	2025-01-15	1
4	Турбулентность-Дон, Группа компаний	разработка и производство приборов учета газа, \nводы, тепла для технического и коммерческого учета	г.Ростов-на-Дону	ненормированный \nрабочий день	Степанов Степан Сергеевич	+7(999)-777-6655	-	бухгалтер	-	-	1С	-	бухучет	70000	-	стаж не менее 5 лет, образование по специальности	2025-01-15	2
5	Турбулентность-Дон, Группа компаний	разработка и производство приборов учета газа, \nводы, тепла для технического и коммерческого учета	г.Ростов-на-Дону	ненормированный \nрабочий день	Степанов Степан Сергеевич	+7(999)-777-6655	-	секретарь делопроизводитель	-	-	общее ПО	английский	делопроизводство	55000	-	стаж не менее 5 лет, образование \nпо специальности	2025-01-15	1
6	ООО "КРОСТ"	крупнейший застройщик России с многолетней репутацией надежного \nработодателя	г. Москва	вахтенный метод	Соловьев Андрей Николаевич	+7(999)-666-5544	м	водитель	-	D	-	-	-	80000	ненормированный рабочий день	стаж не менее 1 года	2024-12-11	1
7	ООО "КРОСТ"	крупнейший застройщик России с многолетней репутацией надежного \nработодателя	г. Москва	вахтенный метод	Соловьев Андрей Николаевич	+7(999)-666-5544	м	инженер-конструктор	I категория	-	инженерное ПО	английский	чертежные работы	120000	ненормированный рабочий день	стаж не менее 5 лет, высшее образование по \nспециальности	2024-12-02	0
\.


--
-- Name: aspirants_aspirant_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.aspirants_aspirant_id_seq', 7, true);


--
-- Name: deals_deal_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.deals_deal_id_seq', 3, true);


--
-- Name: employees_employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employees_employee_id_seq', 4, true);


--
-- Name: vacancys_vacancy_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.vacancys_vacancy_id_seq', 7, true);


--
-- Name: aspirants aspirants_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.aspirants
    ADD CONSTRAINT aspirants_pkey PRIMARY KEY (aspirant_id);


--
-- Name: deals deals_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.deals
    ADD CONSTRAINT deals_pkey PRIMARY KEY (deal_id);


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
-- Name: vacancys vacancys_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vacancys
    ADD CONSTRAINT vacancys_pkey PRIMARY KEY (vacancy_id);


--
-- Name: deals deals_aspirant_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.deals
    ADD CONSTRAINT deals_aspirant_id_fkey FOREIGN KEY (aspirant_id) REFERENCES public.aspirants(aspirant_id);


--
-- Name: deals deals_employee_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.deals
    ADD CONSTRAINT deals_employee_id_fkey FOREIGN KEY (employee_id) REFERENCES public.employees(employee_id);


--
-- Name: deals deals_vacancy_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.deals
    ADD CONSTRAINT deals_vacancy_id_fkey FOREIGN KEY (vacancy_id) REFERENCES public.vacancys(vacancy_id);


--
-- PostgreSQL database dump complete
--

