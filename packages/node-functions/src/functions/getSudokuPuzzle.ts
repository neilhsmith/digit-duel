import {
  app,
  HttpRequest,
  HttpResponseInit,
  InvocationContext,
} from "@azure/functions"
import { getSudoku as generateSudoku } from "sudoku-gen"
import { Difficulty } from "sudoku-gen/dist/types/difficulty.type"

const difficulities = ["easy", "medium", "hard", "expert"]

export async function getSudokuPuzzle(
  request: HttpRequest,
  context: InvocationContext
): Promise<HttpResponseInit> {
  context.log(`Http function processed request for url "${request.url}"`)

  let difficulty: Difficulty

  const searchParam = request.query.get("difficulty")
  if (searchParam) {
    const formattedSearchParam = searchParam.trim().toLowerCase()

    if (difficulities.includes(formattedSearchParam)) {
      difficulty = formattedSearchParam as Difficulty
    } else {
      return {
        status: 400,
        jsonBody: {
          error: `Invalid difficulty "${formattedSearchParam}". Valid difficulties are: ${difficulities.join(
            ", "
          )}`,
        },
      }
    }
  }

  try {
    const sudoku = generateSudoku(difficulty)

    return {
      status: 200,
      jsonBody: {
        result: sudoku,
      },
    }
  } catch (error) {
    return {
      status: 500,
      jsonBody: {
        error: error.message ?? "",
      },
    }
  }
}

app.http("getSudokuPuzzle", {
  methods: ["GET", "POST"],
  authLevel: "anonymous",
  handler: getSudokuPuzzle,
})
