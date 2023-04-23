-- CREATE DATABASE 
CREATE DATABASE globalinsightstribune
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

-- CREATE TABLE NEWS
CREATE TABLE news_table (
    id SERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT,
    contents TEXT,
    author VARCHAR(255),
    source VARCHAR(255),
    date_publication TIMESTAMP NOT NULL DEFAULT now(),
    category_id INTEGER REFERENCES category_table(id)
);

-- CREATE TABLE CATEGORY
CREATE TABLE category_table (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description TEXT
);

-- CREATE TABLE USERS
CREATE TABLE users_table (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL
);

-- CREATE TABLE COMMENTS
CREATE TABLE comments_table (
    id SERIAL PRIMARY KEY,
    text TEXT NOT NULL,
    users_id INTEGER REFERENCES users_table(id),
    news_id INTEGER REFERENCES news_table (id),
    date_publication TIMESTAMP NOT NULL DEFAULT now()
);