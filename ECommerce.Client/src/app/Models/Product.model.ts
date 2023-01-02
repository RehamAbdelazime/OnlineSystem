import { Category } from "./Category.model"

export interface Product{
  id: number
  arabicName: string
  englishName: string
  price: number
  description: string
  hasAvailableStock: boolean
  image : string
  fK_CategoryId: 0
  productCategory ?: Category
}
