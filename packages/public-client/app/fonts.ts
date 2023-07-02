import { Inter, Roboto_Mono } from "next/font/google"

const inter = Inter({
  subsets: ["latin"],
  display: "swap",
  variable: "--font-inter",
})
const roboto_mono = Roboto_Mono({
  subsets: ["latin"],
  display: "swap",
  variable: "--font-roboto-mono",
})

// A space separated of the css vars representing the app's fonts
export const fontVariableString = `${inter.variable} ${roboto_mono.variable}`
