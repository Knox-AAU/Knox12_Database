create schema ${schema};

create table if not exists ${schema}.sources (
    id      serial          primary key,
    name    varchar(100)    not null
);

create table if not exists ${schema}.documents (
    id          bigint       primary key,
    sources_id  integer      not null,
    title       varchar(400) not null,
    path        varchar(400) not null,
    summary     text         not null,
    date        timestamp    not null,
    author      varchar(200) not null,
    total_words integer      not null,
    constraint fk_sources foreign key (sources_id) references ${schema}.sources(id)
);

create table if not exists ${schema}.word_ratios (
    documents_id  bigint  not null,
    word          varchar(100) not null,
    amount        integer not null,
    percent       real not null,
    rank          integer not null,
    constraint fk_documents foreign key (documents_id) references ${schema}.documents(id),
    constraint pk_files_id_word primary key (documents_id, word)
)
