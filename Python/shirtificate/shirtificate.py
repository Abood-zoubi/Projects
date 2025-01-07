from fpdf import FPDF


def main():


    name = input("Name: ")
    pdf = FPDF()
    pdf.add_page()
    pdf.image("shirtificate.png",10,70, w= 190, h = 190)
    pdf.set_margins(0,0)
    pdf.set_font("Arial","B" ,40)
    pdf.text(50,40,"CS50 Shirtificate")
    pdf.set_font("helvetica", "B", 25)
    pdf.set_text_color(255,255,255)
    pdf.text(58,140,txt = name.title() + " took CS50")
    pdf.output("shirtificate.pdf")

if __name__ == "__main__":
    main()