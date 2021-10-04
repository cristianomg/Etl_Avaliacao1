/**********************************************************************************/
--Inserção na Tabela de Departamentos
insert into departamentos ( cod_dpto, nome_dpto ) values ( 001, 'Exatas' );
insert into departamentos ( cod_dpto, nome_dpto ) values ( 002, 'Saúde' );
commit;
/**********************************************************************************/
-- Inserção na Tabela de Cursos
insert into cursos ( cod_curso, nom_curso, cod_dpto ) values ( 0001, 'Ciências da Computação', 001 );
insert into cursos ( cod_curso, nom_curso, cod_dpto ) values ( 0002, 'Engenharia Civil', 001 );
insert into cursos ( cod_curso, nom_curso, cod_dpto ) values ( 0003, 'Medicina', 002 );
commit;
/**********************************************************************************/
-- Inserção na Tabela de Alunos
insert into alunos ( mat_alu, nome, dat_entrada, cod_curso, cotista ) values( 1234567890, 'Vinicius', TO_DATE('2020-01-01', 'yyyy/mm/dd'), 0001, 'N' );
insert into alunos ( mat_alu, nome, dat_entrada, cod_curso, cotista ) values( 1234567891, 'Cristiano', TO_DATE('2020-02-02', 'yyyy/mm/dd'), 0001, 'N' );
insert into alunos ( mat_alu, nome, dat_entrada, cod_curso, cotista ) values( 1234567892, 'Thiago', TO_DATE('2020-03-03', 'yyyy/mm/dd'), 0001, 'N' );
insert into alunos ( mat_alu, nome, dat_entrada, cod_curso, cotista ) values( 1234567893, 'José', TO_DATE('2020-04-04', 'yyyy/mm/dd'), 0001, 'N' );
insert into alunos ( mat_alu, nome, dat_entrada, cod_curso, cotista ) values( 1234567894, 'João', TO_DATE('2020-05-05', 'yyyy/mm/dd'), 0002, 'N' );
insert into alunos ( mat_alu, nome, dat_entrada, cod_curso, cotista ) values( 1234567895, 'Maria', TO_DATE('2020-06-06', 'yyyy/mm/dd'), 0002, 'S' );
insert into alunos ( mat_alu, nome, dat_entrada, cod_curso, cotista ) values( 1234567896, 'Fábio', TO_DATE('2020-07-07', 'yyyy/mm/dd'), 0002, 'S' );
insert into alunos ( mat_alu, nome, dat_entrada, cod_curso, cotista ) values( 1234567897, 'Cida', TO_DATE('2020-08-08', 'yyyy/mm/dd'), 0003, 'S' );
insert into alunos ( mat_alu, nome, dat_entrada, cod_curso, cotista ) values( 1234567898, 'Matheus', TO_DATE('2020-09-09', 'yyyy/mm/dd'), 0003, 'S' );
insert into alunos ( mat_alu, nome, dat_entrada, cod_curso, cotista ) values( 1234567899, 'Lucas', TO_DATE('2020-10-10', 'yyyy/mm/dd'), 0003, 'S' );
commit;
/**********************************************************************************/
--Inserção na Tabela de Disciplinas
insert into disciplinas ( cod_disc, nome_disc, carga_horaria ) values ( 00001, 'Programação Orientada a Objetos', 80.0 );
insert into disciplinas ( cod_disc, nome_disc, carga_horaria ) values ( 00002, 'Banco de Dados', 40.0 );
insert into disciplinas ( cod_disc, nome_disc, carga_horaria ) values ( 00003, 'Analise de Estruturas', 80.0 );
insert into disciplinas ( cod_disc, nome_disc, carga_horaria ) values ( 00004, 'Calculo 1', 40.0 );
insert into disciplinas ( cod_disc, nome_disc, carga_horaria ) values ( 00005, 'Anatomia', 80.0 );
insert into disciplinas ( cod_disc, nome_disc, carga_horaria ) values ( 00006, 'Praticas Medicas', 40.0 );
commit;
/**********************************************************************************/
-- Inserção na Tabela de Matrizes Cursos
insert into matrizes_cursos ( cod_curso, cod_disc, periodo ) values ( 0001, 00001, 1 );
insert into matrizes_cursos ( cod_curso, cod_disc, periodo ) values ( 0001, 00002, 2 );
insert into matrizes_cursos ( cod_curso, cod_disc, periodo ) values ( 0002, 00003, 1 );
insert into matrizes_cursos ( cod_curso, cod_disc, periodo ) values ( 0002, 00004, 2 );
insert into matrizes_cursos ( cod_curso, cod_disc, periodo ) values ( 0003, 00005, 1 );
insert into matrizes_cursos ( cod_curso, cod_disc, periodo ) values ( 0003, 00006, 2 );
commit;
/**********************************************************************************/
-- Inserção na Tabela de Matriculas
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567890, 00001, 9.8, 12, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567890, 00002, 5.9, 10, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567890, 00002, 7.0, 4, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567891, 00001, 7.0, 22, 'T' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567891, 00002, 5.0, 0, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567892, 00001, 4.0, 26, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567893, 00001, 5.7, 6, 'T' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567893, 00002, 8.0, 30, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567893, 00001, 10.0, 0, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567893, 00002, 9.0, 6, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567894, 00003, 2.0, 6, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567894, 00003, 9.0, 0, 'T' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567894, 00004, 10.0, 2, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567895, 00004, 7.5, 26, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567895, 00004, 9.9, 18, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567896, 00003, 6.0, 8, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567897, 00005, 2.0, 8, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567897, 00006, 7.0, 22, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567897, 00005, 8.4, 4, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567897, 00006, 5.8, 8, 'T' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567898, 00005, 10.0, 0, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20211, 1234567898, 00006, 6.0, 30, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567898, 00006, 6.0, 0, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567899, 00005, 7.2, 28, 'A' );
insert into matriculas ( semestre, mat_alu, cod_disc, nota, faltas, status ) values ( 20212, 1234567899, 00006, 6.2, 2, 'A' );
commit;
/**********************************************************************************/