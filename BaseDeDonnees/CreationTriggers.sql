CREATE TRIGGER T_match_D
ON jedi
INSTEAD OF DELETE
AS
    SET NOCOUNT ON
    DELETE FROM match
    WHERE numjedi1 IN (SELECT numjedi FROM deleted) OR
    numjedi2 in (SELECT numjedi FROM deleted)

    DELETE FROM jedi WHERE numjedi IN (SELECT numjedi FROM deleted);