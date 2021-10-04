create user avl1
  identified by "avl1"
  default tablespace DADOS_ACAD
  temporary tablespace TEMP_ACAD
  profile DEFAULT 
  quota unlimited on DADOS_ACAD
  quota unlimited on INDICES_ACAD;


grant connect to avl1;
grant resource to avl1;
grant create view to avl1;

create user dw_avl1
  identified by "dw_avl1"
  default tablespace DADOS_ACAD
  temporary tablespace TEMP_ACAD
  profile DEFAULT 
  quota unlimited on DADOS_ACAD
  quota unlimited on INDICES_ACAD;


grant connect to dw_avl1;
grant resource to dw_avl1;
grant create view to dw_avl1;