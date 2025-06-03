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
-- Name: books; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.books (
    book_id integer NOT NULL,
    author character varying(255) NOT NULL,
    book_name character varying(500) NOT NULL,
    type character varying(100) NOT NULL,
    genre character varying(100),
    publisher character varying(255) NOT NULL,
    publication_year integer NOT NULL,
    page_count integer NOT NULL,
    total_quantity integer NOT NULL,
    available_quantity integer NOT NULL,
    CONSTRAINT books_available_quantity_check CHECK ((available_quantity >= 0)),
    CONSTRAINT books_total_quantity_check CHECK ((total_quantity >= 0))
);


ALTER TABLE public.books OWNER TO postgres;

--
-- Name: books_book_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.books_book_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.books_book_id_seq OWNER TO postgres;

--
-- Name: books_book_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.books_book_id_seq OWNED BY public.books.book_id;


--
-- Name: loans; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.loans (
    loan_id integer NOT NULL,
    reader_id integer,
    book_id integer,
    quantity integer NOT NULL,
    loan_date date NOT NULL,
    return_date date,
    CONSTRAINT loans_quantity_check CHECK ((quantity > 0))
);


ALTER TABLE public.loans OWNER TO postgres;

--
-- Name: loan_with_overdue; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.loan_with_overdue AS
 SELECT loan_id,
    reader_id,
    book_id,
    quantity,
    loan_date,
    return_date,
        CASE
            WHEN ((return_date IS NULL) AND (CURRENT_DATE > (loan_date + 14))) THEN (CURRENT_DATE - (loan_date + 14))
            ELSE 0
        END AS overdue_days
   FROM public.loans;


ALTER VIEW public.loan_with_overdue OWNER TO postgres;

--
-- Name: loans_loan_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.loans_loan_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.loans_loan_id_seq OWNER TO postgres;

--
-- Name: loans_loan_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.loans_loan_id_seq OWNED BY public.loans.loan_id;


--
-- Name: readers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.readers (
    reader_id integer NOT NULL,
    reader_name character varying(255) NOT NULL,
    birth_date date NOT NULL,
    workplace character varying(255),
    phone character varying(50) NOT NULL,
    address character varying(255) NOT NULL,
    email character varying(255) NOT NULL
);


ALTER TABLE public.readers OWNER TO postgres;

--
-- Name: readers_reader_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.readers_reader_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.readers_reader_id_seq OWNER TO postgres;

--
-- Name: readers_reader_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.readers_reader_id_seq OWNED BY public.readers.reader_id;


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
-- Name: books book_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.books ALTER COLUMN book_id SET DEFAULT nextval('public.books_book_id_seq'::regclass);


--
-- Name: loans loan_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.loans ALTER COLUMN loan_id SET DEFAULT nextval('public.loans_loan_id_seq'::regclass);


--
-- Name: readers reader_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.readers ALTER COLUMN reader_id SET DEFAULT nextval('public.readers_reader_id_seq'::regclass);


--
-- Name: users users_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN users_id SET DEFAULT nextval('public.users_users_id_seq'::regclass);


--
-- Data for Name: books; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.books (book_id, author, book_name, type, genre, publisher, publication_year, page_count, total_quantity, available_quantity) FROM stdin;
289	Твен М.	Никогда не спорьте с идиотами!	художественная	сатира	ЭКСМО	2024	160	5	4
498	Нестерова Н	Жребий праведных грешниц	художественная	исторический роман	АСТ	2024	784	6	5
369	Булгаков М	Мастер и Маргарита. Вечные истории	художественная	сатира	Манн, Иванов и Фербер	2024	512	3	2
124	Ожегов С. И.	Толковый словарь русского языка	словари и справочники	филология	АСТ	2020	736	10	8
228	Надежкина Н.В.	Японский язык. 4-в-1: грамматика, разговорник, японско-русский словарь, русско-японский словарь	учебник	филология	Lingua	2022	288	3	3
149	Окошкин В.Т.	Англо-русский русско-английский словарь	словари и справочники	филология	АСТ	2000	96	10	10
114	Перышкин И.М.	Физика. 8 класс. Базовый уровень	учебник	физика	Просвещение	2022	257	10	9
98	Кремер Н.Ш.	Математика для колледжей 12-е изд., пер. и доп. Учебное пособие для СПО	учебник	математика	Просвещение	2018	450	15	15
87	Фленов М. Е.	Библия C#. 6-е издание	словари и справочники	ИТ	BHV	2000	512	2	1
\.


--
-- Data for Name: loans; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.loans (loan_id, reader_id, book_id, quantity, loan_date, return_date) FROM stdin;
1	2	289	1	2024-10-12	\N
2	6	114	1	2024-09-05	2024-10-10
3	7	87	1	2024-08-25	2024-09-06
4	7	87	1	2024-09-06	\N
5	3	369	1	2024-11-07	\N
7	7	124	2	2024-09-10	\N
6	1	498	1	2024-10-25	2025-05-31
\.


--
-- Data for Name: readers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.readers (reader_id, reader_name, birth_date, workplace, phone, address, email) FROM stdin;
1	Бессмертный Кощей Спиридонович	1999-12-12	Охранное агентство Аллигатор, сторож	+7(999)888-88-88	г.Ростов-на-Дону, Красноармейская, 13	kosha@yandex.ru
2	Царевич Иван Иванович	2000-03-09	РГУПС, лаборант	+7(888)999-99-99	г.Ростов-на-Дону, Красноармейская, 15	vanya@yandex.ru
3	Премудрая Василиса Егоровна	1995-10-25	ЮФУ, преподаватель	+7(888)777-77-77	г.Ростов-на-Дону, Красноармейская, 15	lisa@yandex.ru
4	Свистунов Соловей Карпович	1998-04-01	Кинотеатр Чарли, администратор	+7(777)888-88-88	г.Ростов-на-Дону, Красноармейская, 21	mrsvist@yandex.ru
5	Горыныч Змей Драконович	2002-08-19	Пожарная часть № 5, пожарный	+7(777)999-99-99	г.Ростов-на-Дону, Красноармейская, 17	ogon@yandex.ru
6	Болотная Кикимора Аристарховна	2000-02-04	Аквапарк H2O, администратор	+7(888)666-66-66	г.Ростов-на-Дону, Красноармейская, 18	kulic@yandex.ru
7	Муромец Илья Иванович	2004-11-30	ДГТУ, студент	+7(999)666-66-66	г.Ростов-на-Дону, Красноармейская, 25	primeta@yandex.ru
8	Богатырев Добрыня Никитич	1997-06-24	Пожарная часть № 5, пожарный	+7(666)999-99-99	г.Ростов-на-Дону, Красноармейская, 20	upalotjalsya@yandex.ru
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (users_id, login, password) FROM stdin;
1	none	none
\.


--
-- Name: books_book_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.books_book_id_seq', 1, false);


--
-- Name: loans_loan_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.loans_loan_id_seq', 7, true);


--
-- Name: readers_reader_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.readers_reader_id_seq', 8, true);


--
-- Name: users_users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_users_id_seq', 1, true);


--
-- Name: books books_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.books
    ADD CONSTRAINT books_pkey PRIMARY KEY (book_id);


--
-- Name: loans loans_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.loans
    ADD CONSTRAINT loans_pkey PRIMARY KEY (loan_id);


--
-- Name: readers readers_phone_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.readers
    ADD CONSTRAINT readers_phone_key UNIQUE (phone);


--
-- Name: readers readers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.readers
    ADD CONSTRAINT readers_pkey PRIMARY KEY (reader_id);


--
-- Name: users users_login_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_login_key UNIQUE (login);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (users_id);


--
-- Name: idx_book_title; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_book_title ON public.books USING btree (book_name);


--
-- Name: idx_loan_dates; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_loan_dates ON public.loans USING btree (loan_date, return_date);


--
-- Name: idx_reader_name; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_reader_name ON public.readers USING btree (reader_name);


--
-- Name: loans loans_book_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.loans
    ADD CONSTRAINT loans_book_id_fkey FOREIGN KEY (book_id) REFERENCES public.books(book_id) ON DELETE CASCADE;


--
-- Name: loans loans_reader_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.loans
    ADD CONSTRAINT loans_reader_id_fkey FOREIGN KEY (reader_id) REFERENCES public.readers(reader_id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

