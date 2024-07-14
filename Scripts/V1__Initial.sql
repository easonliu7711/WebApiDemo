--
-- PostgreSQL database dump
--

SET
statement_timeout = 0;
SET
lock_timeout = 0;
SET
idle_in_transaction_session_timeout = 0;
SET
client_encoding = 'UTF8';
SET
standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET
check_function_bodies = false;
SET
xmloption = content;
SET
client_min_messages = warning;
SET
row_security = off;

--
-- Name: bms; Type: SCHEMA; Schema: -;
--

CREATE SCHEMA IF NOT EXISTS asp_demo;


SET
default_tablespace = '';

SET
default_table_access_method = heap;

--
-- Name: device_info; Type: TABLE; Schema: asp_demo;
--

CREATE TABLE asp_demo.device_info
(
    id           VARCHAR(50) PRIMARY KEY,
    access_token VARCHAR(50)  NOT NULL,
    type         VARCHAR(50)  NOT NULL,
    name         VARCHAR(100) NOT NULL,
    label        VARCHAR(200) NOT NULL,
    create_time  timestamp with time zone,
    update_time  timestamp with time zone
);
