import struct
#macro arg count ex: macro node 23
E_COMA = '"," is missing in line '
E_REG = "expected a register in line "
E_ATOM = "expected a number or '$' in line "
E_PAREN = "')' expected in line "
E_DIRECTION = "'<' or '>' expected in line "
E_MATH_EXPR = "math expression expected in line "
E_ARG = "argument expected in line "
E_WORD = "word expected in line "
E_UNEXPECTED_DIRECTIVE = "unexpected directive in line "
E_NO_ENDMACRO = "missing @endmacro directive"
E_UNEXPECTED_EXP = "unexpected expression in line "
E_DIF = "missing definition in line "

E_UNEXPECTED_TOKEN_PREPARSE = "unexpected token in line "
E_UNEXPECTED_TOKEN_PREPARSE_EXTRA = ", 'include' or 'define' directive expected"

E_NO_DEF_PREPARSE = "unexpected token in line "
E_NO_DEF_PREPARSE_EXTRA = ", '.def' special word expected"

E_NO_SECTORS = " no sectors found"

E_DEF_NOT_IN_PLACE = " enexpected location of a '.def' sector, line "

E_UNEXPECTED_EXP_DATA_EXTRA = ", 'string', 'var' keyword or 'label' directive expected"

E_INVALID_DATA_EXPR = " invalid data expression in line "
E_NO_CODE_SECTOR = " no '.code' sector found"

#E_UNKNOWN_MACRO Parser 101

ERRORS_IDS = {E_COMA:0,E_REG:1,E_ATOM:2,E_PAREN:3,E_DIRECTION:4,
              E_MATH_EXPR:5,E_ARG:6,E_WORD:7,E_UNEXPECTED_DIRECTIVE:8,E_NO_ENDMACRO:9,
              E_UNEXPECTED_EXP:10,E_DIF:11}

class InvalidSyntaxError(Exception):
    def __init__(self, message, line=-1, extra=""):
        self.base = "Invalid syntax error: "
        self.line = line
        self.extra = extra

        super().__init__(self.base + message + line.__repr__())

        if line != -1:
            self.message = self.base + message + line.__repr__() + self.extra
        else:
            self.message = self.base + message

    def __repr__(self):
        return self.message

    def get_err_repr(self):
        err = self.__repr__() + '\n'
        lin = str(self.line)

        return err + lin + "\nline"

    @staticmethod
    def form_errors_array(errors_array):

        ret = []
        l = len(errors_array)

        for err in errors_array:
            ret += [err.get_err_repr()]

        return ret, l



